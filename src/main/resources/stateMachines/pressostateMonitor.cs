
using Swissframe.Thermos.Common.Contract;

/*
1. We need a StateMachine Interface
2. Generate getter foreach
*/
public interface IStateMachine<S, E, T>
{
    S GetState();
    T? UpdateState(E statEvent)

}

namespace Swissframe.Thermos.Control.Contract
{
    public interface IPressostatMonitor
    {
        int OverpressureCount { get; }
        int PauseCount { get; }
        ITimer TimerDebounce { get; }
        ITimer TimerPause { get; }
        ITimer TimerActive { get; }
        bool IsRequestingPause { get; }
        bool IsRequestingHeatPumpMonitoringStop { get; }

        /// <summary>
        /// Gets the current state.
        /// </summary>
        PressostatMonitorState GetState();
        /// <summary>
        /// Updates the current state based on the specified events.
        /// </summary>
        /// <returns>
        /// The performed state transition if one has been performed; otherwise null.
        /// </returns>
        PressostatMonitorTransition? UpdateState(IPressostatMonitorEventChecker eventChecker);
    }
}

using System;
using Microsoft.Extensions.Logging;
using Stateless;
using Swissframe.Thermos.Common.Contract;
using Swissframe.Thermos.Control.Contract;

namespace Swissframe.Thermos.Control
{
    public class PressostatMonitor : IPressostatMonitor
    {
        private readonly StateMachine<PressostatMonitorState, PressostatMonitorTransition> _stateMachine;
        private readonly ILogger _logger;

        public PressostatMonitor(
            PressostatMonitorState initialState,
            ILogger<PressostatMonitor> logger,
            ITimer timerDebounce,
            ITimer timerActive,
            ITimer timerPause)
        {
            _stateMachine = GetStateMachine(initialState);
            _stateMachine.OnTransitioned(x => _logger.LogInformation($"State transition \"{x.Trigger}\" from state \"{x.Source}\" to state \"{x.Destination}\""));
            _stateMachine.OnUnhandledTrigger((state, transition) =>
            {
                var message = $"Invalid state transition \"{transition}\" from state \"{state}\"";
                _logger.LogError(message);
                throw new Exception(message);
            });

            _logger = logger;
            OverpressureCount = 0;
            PauseCount = 0;
            TimerActive = timerActive;
            TimerDebounce = timerDebounce;
            TimerPause = timerPause;
            IsRequestingPause = false;
        }

        public int OverpressureCount { get; private set; }
        public int PauseCount { get; private set; }
        public ITimer TimerActive { get; }
        public ITimer TimerDebounce { get; }
        public ITimer TimerPause { get; }
        public bool IsRequestingPause { get; private set; }
        public bool IsRequestingHeatPumpMonitoringStop { get; private set; }

        public PressostatMonitorState GetState()
        {
            return _stateMachine.State;
        }

        public PressostatMonitorTransition? UpdateState(IPressostatMonitorEventChecker eventChecker)
        {
            if (eventChecker.IsPauseCountResetRequested())
            {
                PauseCount = 0;
            }
            IsRequestingHeatPumpMonitoringStop = false;

            PressostatMonitorTransition? transition = null;
            switch (GetState())
            {
                // Idle
                case PressostatMonitorState.Idle:
                    if (eventChecker.IsPressostatOverpressureTriggered())
                    {
                        OverpressureCount = 1;
                        TimerDebounce.Start();
                        TimerActive.Start();
                        IsRequestingHeatPumpMonitoringStop = true;
                        transition = FireTransition(PressostatMonitorTransition.Debounce);
                    }
                    break;

                // Debounce
                case PressostatMonitorState.Debounce:
                    if (eventChecker.IsMaximumOvepressureCountExceeded())
                    {
                        PauseCount++;
                        TimerDebounce.StopAndReset();
                        TimerActive.StopAndReset();
                        TimerPause.Start();
                        IsRequestingPause = true;
                        transition = FireTransition(PressostatMonitorTransition.Pause);
                    }
                    else if (eventChecker.IsDebounceDurationExceeded())
                    {
                        TimerDebounce.StopAndReset();
                        transition = FireTransition(PressostatMonitorTransition.Critical);
                    }
                    else if (eventChecker.IsMaximumActiveDurationExceeded())
                    {
                        TimerDebounce.StopAndReset();
                        TimerActive.StopAndReset();
                        transition = FireTransition(PressostatMonitorTransition.Idle);
                    }
                    break;

                // Critical
                case PressostatMonitorState.Critical:
                    if (eventChecker.IsPressostatOverpressureTriggered())
                    {
                        OverpressureCount++;
                        TimerDebounce.StopAndReset();
                        TimerDebounce.Start();
                        transition = FireTransition(PressostatMonitorTransition.Debounce);
                    }
                    else if (eventChecker.IsMaximumActiveDurationExceeded())
                    {
                        OverpressureCount = 0;
                        TimerPause.StopAndReset();
                        transition = FireTransition(PressostatMonitorTransition.Idle);
                    }
                    break;

                // Pause
                case PressostatMonitorState.Pause:
                    if (eventChecker.IsPressostatMonitoringDetectingMalfunction())
                    {
                        TimerDebounce.StopAndReset();
                        TimerActive.StopAndReset();
                        TimerPause.StopAndReset();
                        IsRequestingPause = false;
                        transition = FireTransition(PressostatMonitorTransition.Malfunction);
                    }
                    else if (eventChecker.IsPauseDurationExceeded())
                    {
                        OverpressureCount = 0;
                        TimerPause.StopAndReset();
                        IsRequestingPause = false;
                        transition = FireTransition(PressostatMonitorTransition.Idle);
                    }
                    break;

                // Malfunction
                case PressostatMonitorState.Malfunction:
                    // No state transitions
                    break;

                default:
                    throw new NotImplementedException($"Unhandled state \"{_stateMachine.State}\"");
            }

            return transition;
        }

        private PressostatMonitorTransition FireTransition(PressostatMonitorTransition transition)
        {
            _stateMachine.Fire(transition);
            return transition;
        }

        private static StateMachine<PressostatMonitorState, PressostatMonitorTransition> GetStateMachine(PressostatMonitorState initialState)
        {
            var stateMachine = new StateMachine<PressostatMonitorState, PressostatMonitorTransition>(initialState);

            stateMachine.Configure(PressostatMonitorState.Idle)
                .Permit(PressostatMonitorTransition.Debounce, PressostatMonitorState.Debounce);

            stateMachine.Configure(PressostatMonitorState.Debounce)
                .Permit(PressostatMonitorTransition.Idle, PressostatMonitorState.Idle)
                .Permit(PressostatMonitorTransition.Critical, PressostatMonitorState.Critical)
                .Permit(PressostatMonitorTransition.Pause, PressostatMonitorState.Pause);

            stateMachine.Configure(PressostatMonitorState.Critical)
                .Permit(PressostatMonitorTransition.Idle, PressostatMonitorState.Idle)
                .Permit(PressostatMonitorTransition.Debounce, PressostatMonitorState.Debounce);

            stateMachine.Configure(PressostatMonitorState.Pause)
                .Permit(PressostatMonitorTransition.Idle, PressostatMonitorState.Idle)
                .Permit(PressostatMonitorTransition.Malfunction, PressostatMonitorState.Malfunction);

            return stateMachine;
        }
    }
}