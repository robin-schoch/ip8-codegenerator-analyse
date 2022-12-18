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
        private const string Idle = nameOf(Idle);
        private const string Debounce = nameOf(Debounce);
        private const string Critical = nameOf(Critical);
        private const string Pause = nameOf(Pause);
        private const string Malfunction = nameOf(Malfunction);

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
                Idle => IdleState();
                Debounce => DebounceState();
                Critical => CriticalState();
                Pause => PauseState();
                Malfunction => MalfunctionState();
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
            if((_registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset  == _registry.Constant_True)) {
    _registry.Variable_PressostatMonitor_PauseCount = 0;
}

            if (Event0())
            {
                
                _registry.Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop = _registry.Constant_True;
                _registry.Timer_PressostatMonitor_Active.Start()
                _registry.Timer_PressostatMonitor_Debounce.Start()
                _registry.Variable_PressostatMonitor_OverpressureCount = _registry.Constant_One;
                return Debounce;
            }


            return Idle;
        }
        private string DebounceState()
        {
            
            _registry.Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;
            if((_registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset  == _registry.Constant_True)) {
    _registry.Variable_PressostatMonitor_PauseCount = 0;
}

            if (Event1())
            {
                
                _registry.Variable_PressostatMonitor_IsRequestingPause = _registry.Constant_True;
                _registry.Timer_PressostatMonitor_Pause.Start()
                TODO()
                TODO()
                _registry.Variable_PressostatMonitor_PauseCount++;
                return Pause;
            }

            if (Event2())
            {
                
                TODO()
                return Critical;
            }

            if (Event3())
            {
                
                TODO()
                TODO()
                return Idle;
            }


            return Debounce;
        }
        private string CriticalState()
        {
            
            _registry.Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;
            if((_registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset  == _registry.Constant_True)) {
    _registry.Variable_PressostatMonitor_PauseCount = 0;
}

            if (Event0())
            {
                
                _registry.Timer_PressostatMonitor_Debounce.Start()
                TODO()
                _registry.Variable_PressostatMonitor_OverpressureCount++;
                return Debounce;
            }

            if (Event3())
            {
                
                TODO()
                TODO()
                _registry.Variable_PressostatMonitor_OverpressureCount = 0;
                return Idle;
            }


            return Critical;
        }
        private string PauseState()
        {
            
            _registry.Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;
            if((_registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset  == _registry.Constant_True)) {
    _registry.Variable_PressostatMonitor_PauseCount = 0;
}

            if (Event4())
            {
                
                _registry.Variable_PressostatMonitor_IsRequestingPause = _registry.Constant_False;
                TODO()
                TODO()
                TODO()
                return Malfunction;
            }

            if (Event5())
            {
                
                _registry.Variable_PressostatMonitor_IsRequestingPause = _registry.Constant_False;
                TODO()
                TODO()
                _registry.Variable_PressostatMonitor_OverpressureCount = 0;
                return Idle;
            }


            return Pause;
        }
        private string MalfunctionState()
        {
            
            _registry.Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;
            if((_registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset  == _registry.Constant_True)) {
    _registry.Variable_PressostatMonitor_PauseCount = 0;
}


            return Malfunction;
        }

        private bool Event0()
        {
            var result = (_registry.Sensor_ReadIsHeatPumpOverpressureTriggeredWithClearAfterRead  == _registry.Constant_True);
            _logger.LogDebug("Event: Event0() (16122b37-6634-477e-b486-0b04a219ca11) evaluates to {result}", result);
            return result;
        } 

        private bool Event1()
        {
            var result = (_registry.Variable_PressostatMonitor_OverpressureCount  >= _registry.Config_PressostatMonitorConfiguration::MaximumOverpressureCount);
            _logger.LogDebug("Event: Event1() (298d745f-91e6-4281-87dc-c86f267e4265) evaluates to {result}", result);
            return result;
        } 

        private bool Event2()
        {
            var result = (_registry.Timer_PressostatMonitor_Debounce  >= _registry.Config_PressostatMonitorConfiguration::DebounceDurationSeconds);
            _logger.LogDebug("Event: Event2() (aef06d5e-4489-4607-84d4-b9163117f135) evaluates to {result}", result);
            return result;
        } 

        private bool Event3()
        {
            var result = (_registry.Timer_PressostatMonitor_Active  >= _registry.Config_PressostatMonitorConfiguration::MaximumActiveDurationMinutes);
            _logger.LogDebug("Event: Event3() (53b06a3e-cbd8-49a3-9ba1-5f054b991e15) evaluates to {result}", result);
            return result;
        } 

        private bool Event4()
        {
            var result = (_registry.Variable_PressostatPauseMonitor_IsDetectingMalfunction  == _registry.Constant_True);
            _logger.LogDebug("Event: Event4() (b170683b-d5a6-4caa-b37d-405304f9fc41) evaluates to {result}", result);
            return result;
        } 

        private bool Event5()
        {
            var result = (_registry.Timer_PressostatMonitor_Pause  >= _registry.Config_PressostatMonitorConfiguration::MaximumPauseDurationMinutes);
            _logger.LogDebug("Event: Event5() (ec35add6-f3c5-4227-896b-8c653adc784d) evaluates to {result}", result);
            return result;
        } 

    }
}