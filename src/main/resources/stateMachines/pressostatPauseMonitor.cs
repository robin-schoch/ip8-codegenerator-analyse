using Swissframe.Thermos.Common.Contract;

namespace Swissframe.Thermos.Control.Contract
{
    public interface IPressostatPauseMonitor
    {
        ITimer TimerActive { get; }
        bool IsRequestingPauseCountReset { get; }
        bool IsDetectingMalfunction { get; }

        /// <summary>
        /// Gets the current state.
        /// </summary>
        PressostatPauseMonitorState GetState();
        /// <summary>
        /// Updates the current state based on the specified events.
        /// </summary>
        /// <returns>
        /// The performed state transition if one has been performed; otherwise null.
        /// </returns>
        PressostatPauseMonitorTransition? UpdateState(IPressostatPauseMonitorEventChecker eventChecker);
    }
}

using System;
using Microsoft.Extensions.Logging;
using Stateless;
using Swissframe.Thermos.Common.Contract;
using Swissframe.Thermos.Control.Contract;

namespace Swissframe.Thermos.Control
{
    public class PressostatPauseMonitor : IPressostatPauseMonitor
    {
        private readonly StateMachine<PressostatPauseMonitorState, PressostatPauseMonitorTransition> _stateMachine;
        private readonly ILogger _logger;

        public PressostatPauseMonitor(
            PressostatPauseMonitorState initialState,
            ILogger<PressostatPauseMonitor> logger,
            ITimer timerActive)
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
            TimerActive = timerActive;
            IsRequestingPauseCountReset = false;
            IsDetectingMalfunction = false;
        }

        public ITimer TimerActive { get; }
        public bool IsRequestingPauseCountReset { get; private set; }
        public bool IsDetectingMalfunction { get; private set; }

        public PressostatPauseMonitorState GetState()
        {
            return _stateMachine.State;
        }

        public PressostatPauseMonitorTransition? UpdateState(IPressostatPauseMonitorEventChecker eventChecker)
        {
            IsRequestingPauseCountReset = false;
            PressostatPauseMonitorTransition? transition = null;

            switch (GetState())
            {
                // Idle
                case PressostatPauseMonitorState.Idle:
                    if (eventChecker.IsPauseCountAbove0()) {
                        TimerActive.Start();
                        transition = FireTransition(PressostatPauseMonitorTransition.Active);
                    }
                    break;

                // Active
                case PressostatPauseMonitorState.Active:
                    if (eventChecker.IsMaximumPauseCountExceeded())
                    {
                        TimerActive.StopAndReset();
                        IsDetectingMalfunction = true;
                        transition = FireTransition(PressostatPauseMonitorTransition.Malfunction);
                    }
                    else if (eventChecker.IsMaximumActiveDurationExceeded())
                    {
                        TimerActive.StopAndReset();
                        IsRequestingPauseCountReset = true;
                        transition = FireTransition(PressostatPauseMonitorTransition.Idle);
                    }
                    break;

                // Malfunction
                case PressostatPauseMonitorState.Malfunction:
                    // No state transitions
                    break;

                default:
                    throw new NotImplementedException($"Unhandled state \"{_stateMachine.State}\"");
            }

            return transition;
        }

        private PressostatPauseMonitorTransition FireTransition(PressostatPauseMonitorTransition transition)
        {
            _stateMachine.Fire(transition);
            return transition;
        }

        private static StateMachine<PressostatPauseMonitorState, PressostatPauseMonitorTransition> GetStateMachine(PressostatPauseMonitorState initialState)
        {
            var stateMachine = new StateMachine<PressostatPauseMonitorState, PressostatPauseMonitorTransition>(initialState);

            stateMachine.Configure(PressostatPauseMonitorState.Idle)
                .Permit(PressostatPauseMonitorTransition.Active, PressostatPauseMonitorState.Active);

            stateMachine.Configure(PressostatPauseMonitorState.Active)
                .Permit(PressostatPauseMonitorTransition.Idle, PressostatPauseMonitorState.Idle)
                .Permit(PressostatPauseMonitorTransition.Malfunction, PressostatPauseMonitorState.Malfunction);

            return stateMachine;
        }
    }
}