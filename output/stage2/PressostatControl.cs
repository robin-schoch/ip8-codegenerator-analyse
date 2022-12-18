using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swissframe.Thermos.Common.Contract;
using Swissframe.Thermos.Control.Contract.HeatPump;
using Swissframe.Thermos.Hardware.Contract;

namespace Swissframe.Util.StateEventEditor.Common.Test
{

    public class PressostatControl
    {
        private const string Idle = nameOf(Idle);
        private const string Pause = nameOf(Pause);
        private const string Emergency_Off = nameOf(Emergency_Off);

        private readonly IServiceProvider _serviceProvider;
        private readonly Registry _registry;
        private readonly ILogger _logger;

        private string _currentState = Idle;

        public PressostatControl(IServiceProvider serviceProvider, Registry registry, ILogger logger)
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
                Pause => PauseState();
                Emergency_Off => Emergency_OffState();
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
            
            _registry.Variable_PressostatControl_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;

            if (Event28())
            {
                
                TODO()
                _registry.Variable_PressostatControl_PauseCount++;
                _registry.Variable_PressostatControl_OverpressureCount++;
                _registry.Variable_PressostatControl_IsRequestingHeatPumpMonitoringStop = _registry.Constant_True;
                _registry.Variable_PressostatControl_IsRequestingHeatPumpPause = _registry.Constant_True;
                _registry.Timer_PressostatControl_Pause.Start()
                return Pause;
            }


            return Idle;
        }
        private string PauseState()
        {
            
            _registry.Variable_PressostatControl_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;

            if (Event28())
            {
                
                _registry.Variable_PressostatControl_OverpressureCount++;
                return Pause;
            }

            if (Event29())
            {
                
                _registry.Variable_PressostatControl_IsRequestingHeatPumpPause = _registry.Constant_False;
                TODO()
                return Idle;
            }

            if (Event30())
            {
                
                TODO()
                return Emergency_Off;
            }


            return Pause;
        }
        private string Emergency_OffState()
        {
            
            _registry.Variable_PressostatControl_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;


            return Emergency_Off;
        }

        private bool Event30()
        {
            var result = (_registry.Variable_PressostatControl_PauseCount  > _registry.Config_PressostatControlConfiguration::MaximumPauseCount);
            _logger.LogDebug("Event: Event30() (f25ca455-fc1a-4b2a-be74-73385a432106) evaluates to {result}", result);
            return result;
        } 

        private bool Event28()
        {
            var result = (_registry.Sensor_ReadIsHeatPumpOverpressureTriggeredWithClearAfterRead  == _registry.Constant_True);
            _logger.LogDebug("Event: Event28() (8a44a3ac-841a-42d3-a917-720facc8c3c0) evaluates to {result}", result);
            return result;
        } 

        private bool Event29()
        {
            var result = (_registry.Timer_PressostatControl_Pause  >= _registry.Config_PressostatControlConfiguration::PauseDurationMinutes);
            _logger.LogDebug("Event: Event29() (dcf263c2-2adb-43b3-b347-3f05c82b0300) evaluates to {result}", result);
            return result;
        } 

    }
}