using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swissframe.Thermos.Common.Contract;
using Swissframe.Thermos.Control.Contract.HeatPump;
using Swissframe.Thermos.Hardware.Contract;

namespace Swissframe.Util.StateEventEditor.Common.Test
{

    public class PressostatMonitor
    {
        private const string Idle = nameof(Idle);
        private const string Debounce = nameof(Debounce);
        private const string Critical = nameof(Critical);
        private const string Pause = nameof(Pause);
        private const string Malfunction = nameof(Malfunction);

        private readonly IServiceProvider _serviceProvider;
        private readonly Registry _registry;
        private readonly ILogger _logger;

        private string _currentState = Idle;

        public PressostatMonitor(IServiceProvider serviceProvider, Registry registry, ILogger logger)
        {
            _serviceProvider = serviceProvider;
            _registry = registry;
            _logger = logger;
        }

        public void UpdateState()
        {
            var nextState = _currentState switch
            {
                Idle => IdleState(),
                Debounce => DebounceState(),
                Critical => CriticalState(),
                Pause => PauseState(),
                Malfunction => MalfunctionState(),
                _ => throw new ArgumentOutOfRangeException()
            };

            if (nextState != _currentState)
            {
                _logger.LogInformation("perform transition from {source} to {target}", _currentState, nextState);
            }
            _currentState = nextState;
        }

        private string IdleState()
        {

                    _registry.Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;
                    if((_registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset  == _registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset)) {
    _registry.Variable_PressostatMonitor_PauseCount = 0;
}

                if (Event16122b37())
                {
                    
                    _registry.Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop = _registry.Constant_True;
                    _registry.Timer_PressostatMonitor_Active.Start();
                    _registry.Timer_PressostatMonitor_Debounce.Start();
                    _registry.Variable_PressostatMonitor_OverpressureCount = _registry.Constant_One;
                    return Debounce;
                }

            return Idle;
        }

        private string DebounceState()
        {

                    _registry.Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;
                    if((_registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset  == _registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset)) {
    _registry.Variable_PressostatMonitor_PauseCount = 0;
}

                if (Event298d745f())
                {
                    
                    _registry.Variable_PressostatMonitor_IsRequestingPause = _registry.Constant_True;
                    _registry.Timer_PressostatMonitor_Pause.Start();
                    // TODO implement templates
                    // TODO implement templates
                    _registry.Variable_PressostatMonitor_PauseCount++;
                    return Pause;
                }
                if (Eventaef06d5e())
                {
                    
                    // TODO implement templates
                    return Critical;
                }
                if (Event53b06a3e())
                {
                    
                    // TODO implement templates
                    // TODO implement templates
                    return Idle;
                }

            return Debounce;
        }

        private string CriticalState()
        {

                    _registry.Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;
                    if((_registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset  == _registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset)) {
    _registry.Variable_PressostatMonitor_PauseCount = 0;
}

                if (Event16122b37())
                {
                    
                    _registry.Timer_PressostatMonitor_Debounce.Start();
                    // TODO implement templates
                    _registry.Variable_PressostatMonitor_OverpressureCount++;
                    return Debounce;
                }
                if (Event53b06a3e())
                {
                    
                    // TODO implement templates
                    // TODO implement templates
                    _registry.Variable_PressostatMonitor_OverpressureCount = 0;
                    return Idle;
                }

            return Critical;
        }

        private string PauseState()
        {

                    _registry.Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;
                    if((_registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset  == _registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset)) {
    _registry.Variable_PressostatMonitor_PauseCount = 0;
}

                if (Eventb170683b())
                {
                    
                    _registry.Variable_PressostatMonitor_IsRequestingPause = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Eventec35add6())
                {
                    
                    _registry.Variable_PressostatMonitor_IsRequestingPause = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    _registry.Variable_PressostatMonitor_OverpressureCount = 0;
                    return Idle;
                }

            return Pause;
        }

        private string MalfunctionState()
        {

                    _registry.Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;
                    if((_registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset  == _registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset)) {
    _registry.Variable_PressostatMonitor_PauseCount = 0;
}


            return Malfunction;
        }



        private bool Event16122b37()
        {
            var result = (_registry.Sensor_ReadIsHeatPumpOverpressureTriggeredWithClearAfterRead  == _registry.Sensor_ReadIsHeatPumpOverpressureTriggeredWithClearAfterRead);
            _logger.LogDebug("Event: Event16122b37() evaluates to {result}", result);
            return result;
        } 
        private bool Event298d745f()
        {
            var result = (_registry.Variable_PressostatMonitor_OverpressureCount  >= _registry.Variable_PressostatMonitor_OverpressureCount);
            _logger.LogDebug("Event: Event298d745f() evaluates to {result}", result);
            return result;
        } 
        private bool Eventaef06d5e()
        {
            var result = (_registry.Variable_PressostatMonitor_OverpressureCount.ElapsedTime.TotalMinutes  >= _registry.Variable_PressostatMonitor_OverpressureCount.ElapsedTime.TotalMinutes);
            _logger.LogDebug("Event: Eventaef06d5e() evaluates to {result}", result);
            return result;
        } 
        private bool Event53b06a3e()
        {
            var result = (_registry.Timer_PressostatMonitor_Active  >= _registry.Timer_PressostatMonitor_Active);
            _logger.LogDebug("Event: Event53b06a3e() evaluates to {result}", result);
            return result;
        } 
        private bool Eventb170683b()
        {
            var result = (_registry.Variable_PressostatPauseMonitor_IsDetectingMalfunction  == _registry.Variable_PressostatPauseMonitor_IsDetectingMalfunction);
            _logger.LogDebug("Event: Eventb170683b() evaluates to {result}", result);
            return result;
        } 
        private bool Eventec35add6()
        {
            var result = (_registry.Timer_PressostatMonitor_Pause  >= _registry.Timer_PressostatMonitor_Pause);
            _logger.LogDebug("Event: Eventec35add6() evaluates to {result}", result);
            return result;
        } 
    }
}