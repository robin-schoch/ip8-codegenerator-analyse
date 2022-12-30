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

        private string _currentState = [Idle];

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

                if (Event8a44a3ac-841a-42d3-a917-720facc8c3c0())
                {
                    
                    // TODO implement templates
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

                if (Event8a44a3ac-841a-42d3-a917-720facc8c3c0())
                {
                    
                    _registry.Variable_PressostatControl_OverpressureCount++;
                    return Pause;
                }
                if (Eventdcf263c2-2adb-43b3-b347-3f05c82b0300())
                {
                    
                    _registry.Variable_PressostatControl_IsRequestingHeatPumpPause = _registry.Constant_False;
                    // TODO implement templates
                    return Idle;
                }
                if (Eventf25ca455-fc1a-4b2a-be74-73385a432106())
                {
                    
                    // TODO implement templates
                    return Emergency_Off;
                }

            return Pause;
        }

        private string Emergency_OffState()
        {
            
                    _registry.Variable_PressostatControl_IsRequestingHeatPumpMonitoringStop = _registry.Constant_False;


            return Emergency_Off;
        }



        private bool Eventf25ca455-fc1a-4b2a-be74-73385a432106()
        {
            var result = (_registry.Variable_PressostatControl_PauseCount  > _registry.Variable_PressostatControl_PauseCount);
            _logger.LogDebug("Event: Eventf25ca455-fc1a-4b2a-be74-73385a432106()(f25ca455-fc1a-4b2a-be74-73385a432106) evaluates to {result}", result);
            return result;
        } 
        private bool Event8a44a3ac-841a-42d3-a917-720facc8c3c0()
        {
            var result = (_registry.Sensor_ReadIsHeatPumpOverpressureTriggeredWithClearAfterRead  == _registry.Sensor_ReadIsHeatPumpOverpressureTriggeredWithClearAfterRead);
            _logger.LogDebug("Event: Event8a44a3ac-841a-42d3-a917-720facc8c3c0()(8a44a3ac-841a-42d3-a917-720facc8c3c0) evaluates to {result}", result);
            return result;
        } 
        private bool Eventdcf263c2-2adb-43b3-b347-3f05c82b0300()
        {
            var result = (_registry.Timer_PressostatControl_Pause  >= _registry.Timer_PressostatControl_Pause);
            _logger.LogDebug("Event: Eventdcf263c2-2adb-43b3-b347-3f05c82b0300()(dcf263c2-2adb-43b3-b347-3f05c82b0300) evaluates to {result}", result);
            return result;
        } 
    }
}