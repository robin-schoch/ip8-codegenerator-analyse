using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swissframe.Thermos.Common.Contract;
using Swissframe.Thermos.Control.Contract.HeatPump;
using Swissframe.Thermos.Hardware.Contract;

namespace Swissframe.Util.StateEventEditor.Common.Test
{

    public class HeatPumpControl
    {
        private const string Idle = nameOf(Idle);
        private const string Normal = nameOf(Normal);
        private const string Critical_1 = nameOf(Critical_1);
        private const string Critical_2 = nameOf(Critical_2);
        private const string Critical_3 = nameOf(Critical_3);
        private const string Defrost = nameOf(Defrost);
        private const string Drip_off = nameOf(Drip_off);
        private const string Pause = nameOf(Pause);
        private const string Malfunction = nameOf(Malfunction);

        private readonly IServiceProvider _serviceProvider;
        private readonly Registry _registry;
        private readonly ILogger _logger;

        private string _currentState = Idle;

        public HeatPumpControl(IServiceProvider serviceProvider, Registry registry, ILogger logger)
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
                Normal => NormalState();
                Critical_1 => Critical_1State();
                Critical_2 => Critical_2State();
                Critical_3 => Critical_3State();
                Defrost => DefrostState();
                Drip_off => Drip_offState();
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
            
            TODO()
            _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

            if (Event9())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                TODO()
                TODO()
                TODO()
                return Malfunction;
            }

            if (Event10())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                TODO()
                TODO()
                TODO()
                return Pause;
            }

            if (Event12())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_True;
                return Normal;
            }

            if (Event13())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_True;
                return Critical_1;
            }


            return Idle;
        }
        private string NormalState()
        {
            
            TODO()
            _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

            if (Event9())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                TODO()
                TODO()
                TODO()
                return Malfunction;
            }

            if (Event10())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                TODO()
                TODO()
                TODO()
                return Pause;
            }

            if (Event14())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                return Idle;
            }

            if (Event15())
            {
                
                _registry.Timer_HeatPumpControl_TimerCritical1.Start()
                return Critical_1;
            }


            return Normal;
        }
        private string Critical_1State()
        {
            
            TODO()
            _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

            if (Event9())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                TODO()
                TODO()
                TODO()
                return Malfunction;
            }

            if (Event10())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                TODO()
                TODO()
                TODO()
                return Pause;
            }

            if (Event14())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                TODO()
                return Idle;
            }

            if (Event16())
            {
                
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                TODO()
                return Normal;
            }

            if (Event17())
            {
                
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (Level2);
                _registry.Timer_HeatPumpControl_TimerCritical2.Start()
                return Critical_2;
            }

            if (Event18())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_True;
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (DefrostOrDripOff);
                TODO()
                return Defrost;
            }


            return Critical_1;
        }
        private string Critical_2State()
        {
            
            TODO()
            _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

            if (Event9())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                TODO()
                TODO()
                TODO()
                return Malfunction;
            }

            if (Event10())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                TODO()
                TODO()
                TODO()
                return Pause;
            }

            if (Event14())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                TODO()
                TODO()
                return Idle;
            }

            if (Event16())
            {
                
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                TODO()
                TODO()
                return Normal;
            }

            if (Event19())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_True;
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (DefrostOrDripOff);
                TODO()
                TODO()
                return Defrost;
            }

            if (Event20())
            {
                
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (Level3);
                return Critical_3;
            }


            return Critical_2;
        }
        private string Critical_3State()
        {
            
            TODO()
            _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

            if (Event9())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                TODO()
                TODO()
                TODO()
                return Malfunction;
            }

            if (Event10())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                TODO()
                TODO()
                TODO()
                return Pause;
            }

            if (Event14())
            {
                
                TODO()
                TODO()
                return Idle;
            }

            if (Event19())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_True;
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (DefrostOrDripOff);
                TODO()
                TODO()
                return Defrost;
            }

            if (Event21())
            {
                
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (Level2);
                return Critical_2;
            }


            return Critical_3;
        }
        private string DefrostState()
        {
            
            TODO()
            _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

            if (Event9())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                TODO()
                TODO()
                TODO()
                return Malfunction;
            }

            if (Event10())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                TODO()
                TODO()
                TODO()
                return Pause;
            }

            if (Event22())
            {
                
                _registry.Timer_HeatPumpControl_TimerDripOff.Start()
                return Drip_off;
            }


            return Defrost;
        }
        private string Drip_offState()
        {
            
            TODO()
            _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

            if (Event9())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                TODO()
                TODO()
                TODO()
                return Malfunction;
            }

            if (Event10())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                TODO()
                TODO()
                TODO()
                return Pause;
            }

            if (Event23())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_True;
                _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                TODO()
                return Normal;
            }


            return Drip_off;
        }
        private string PauseState()
        {
            
            TODO()
            _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

            if (Event9())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                TODO()
                TODO()
                TODO()
                return Malfunction;
            }

            if (Event11())
            {
                
                _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_True;
                return Normal;
            }


            return Pause;
        }
        private string MalfunctionState()
        {
            
            TODO()
            _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;


            return Malfunction;
        }

        private bool Event9()
        {
            var result = ((_registry.Variable_PressostatPauseMonitor_IsDetectingMalfunction  == _registry.Constant_True) || (_registry.Variable_VentilationPauseMonitor_IsDetectingMalfunction  == _registry.Constant_True) || (_registry.Variable_HeatGenerationPauseMonitor_IsDetectingMalfunction  == _registry.Constant_True));
            _logger.LogDebug("Event: Event9() (13262a8a-1ee5-4b4e-9de3-3e8d3fda2c7a) evaluates to {result}", result);
            return result;
        } 

        private bool Event10()
        {
            var result = ((_registry.Variable_PressostatMonitor_IsRequestingPause  == _registry.Constant_True) || (_registry.Variable_VentilationMonitor_IsRequestingPause  == _registry.Constant_True) || (_registry.Variable_HeatGenerationMonitor_IsRequestingPause  == _registry.Constant_True) || (_registry.Constant_DateTimeNow  < _registry.Sensor_ReadControlPanelAwayUntil));
            _logger.LogDebug("Event: Event10() (7249892c-71a6-445c-9c4f-467967f35749) evaluates to {result}", result);
            return result;
        } 

        private bool Event14()
        {
            var result = (((_registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed  == _registry.Constant_True) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Constant_True) || (_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_One)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumScoL1DegreesCelsius)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_Two) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumScoL2DegreesCelsius)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_Three) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumScoL3DegreesCelsius)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumNormalDegreesCelsius));
            _logger.LogDebug("Event: Event14() (7fba458b-4b48-4374-9f10-2047f5a81b31) evaluates to {result}", result);
            return result;
        } 

        private bool Event12()
        {
            var result = ((((_registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed  == _registry.Constant_True) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Constant_True) || (_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_One)) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMinimumScoL1DegreesCelsius)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_Two) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMinimumScoL2DegreesCelsius)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_Three) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMinimumScoL3DegreesCelsius)))) || (_registry.Sensor_ReadReservoirTemperature  < _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMinimumNormalDegreesCelsius)) && (_registry.Sensor_ReadEvaporatorTemperature  >= _registry.Config_HeatPumpControlConfiguration::EvaporatorTemperatureCritical1DegreesCelsius));
            _logger.LogDebug("Event: Event12() (f3013826-caaa-499e-8e63-73483faeb0b4) evaluates to {result}", result);
            return result;
        } 

        private bool Event16()
        {
            var result = (((((_registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed  == _registry.Constant_True) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Constant_True) || (_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_One)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumScoL1DegreesCelsius)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_Two) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumScoL2DegreesCelsius)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_Three) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumScoL3DegreesCelsius)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumNormalDegreesCelsius))  == _registry.Constant_False) && (_registry.Sensor_ReadEvaporatorTemperature  >= _registry.Config_HeatPumpControlConfiguration::EvaporatorTemperatureCritical1DegreesCelsius));
            _logger.LogDebug("Event: Event16() (5136e5fa-6a8f-4ea6-a3a2-c0483fa1ce05) evaluates to {result}", result);
            return result;
        } 

        private bool Event13()
        {
            var result = ((((_registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed  == _registry.Constant_True) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Constant_True) || (_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_One)) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMinimumScoL1DegreesCelsius)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_Two) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMinimumScoL2DegreesCelsius)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_Three) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMinimumScoL3DegreesCelsius)))) || (_registry.Sensor_ReadReservoirTemperature  < _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMinimumNormalDegreesCelsius)) && (_registry.Sensor_ReadEvaporatorTemperature  < _registry.Config_HeatPumpControlConfiguration::EvaporatorTemperatureCritical1DegreesCelsius));
            _logger.LogDebug("Event: Event13() (8119625f-7543-4667-ad8e-71a55e2cb931) evaluates to {result}", result);
            return result;
        } 

        private bool Event15()
        {
            var result = (((((_registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed  == _registry.Constant_True) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Constant_True) || (_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_One)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumScoL1DegreesCelsius)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_Two) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumScoL2DegreesCelsius)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Constant_Three) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumScoL3DegreesCelsius)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumNormalDegreesCelsius))  == _registry.Constant_False) && (_registry.Sensor_ReadEvaporatorTemperature  < _registry.Config_HeatPumpControlConfiguration::EvaporatorTemperatureCritical1DegreesCelsius));
            _logger.LogDebug("Event: Event15() (dd0ff77c-dc2f-4ac4-9861-8d49610599a5) evaluates to {result}", result);
            return result;
        } 

        private bool Event17()
        {
            var result = (_registry.Sensor_ReadEvaporatorTemperature  < _registry.Config_HeatPumpControlConfiguration::EvaporatorTemperatureCritical2DegreesCelsius);
            _logger.LogDebug("Event: Event17() (2add766c-99f6-4a5f-bc2c-bf10b0bbc124) evaluates to {result}", result);
            return result;
        } 

        private bool Event21()
        {
            var result = (_registry.Sensor_ReadEvaporatorTemperature  > _registry.Config_HeatPumpControlConfiguration::EvaporatorTemperatureCritical2DegreesCelsius);
            _logger.LogDebug("Event: Event21() (a1619a6c-c448-49de-a93f-2bc24ca8a0ee) evaluates to {result}", result);
            return result;
        } 

        private bool Event18()
        {
            var result = (_registry.Timer_HeatPumpControl_TimerCritical1  > _registry.Config_HeatPumpControlConfiguration::Critical1MaximumTimeMinutes);
            _logger.LogDebug("Event: Event18() (6cf50e40-47f1-4d99-ab1a-aa7bfa43ebb7) evaluates to {result}", result);
            return result;
        } 

        private bool Event19()
        {
            var result = ((_registry.Sensor_ReadEvaporatorTemperature  <= _registry.Config_HeatPumpControlConfiguration::EvaporatorTemperatureMinimumDegreesCelsius) || (_registry.Timer_HeatPumpControl_TimerCritical1  > _registry.Config_HeatPumpControlConfiguration::Critical1MaximumTimeMinutes) || (_registry.Timer_HeatPumpControl_TimerCritical2  > _registry.Config_HeatPumpControlConfiguration::Critical2MaximumTimeMinutes));
            _logger.LogDebug("Event: Event19() (e5a96ea6-6843-4a9c-b5de-6ae1a1ff4092) evaluates to {result}", result);
            return result;
        } 

        private bool Event20()
        {
            var result = (_registry.Sensor_ReadEvaporatorTemperature  <= _registry.Config_HeatPumpControlConfiguration::EvaporatorTemperatureCritical3DegreesCelsius);
            _logger.LogDebug("Event: Event20() (01864e49-feac-436a-97ac-31860a37ca92) evaluates to {result}", result);
            return result;
        } 

        private bool Event23()
        {
            var result = (_registry.Timer_HeatPumpControl_TimerDripOff  >= _registry.Config_HeatPumpControlConfiguration::DripOffTimeMinutes);
            _logger.LogDebug("Event: Event23() (0c4189b5-76fa-4d97-bf9f-fd1653b1eee7) evaluates to {result}", result);
            return result;
        } 

        private bool Event11()
        {
            var result = (((_registry.Variable_PressostatMonitor_IsRequestingPause  == _registry.Constant_True) || (_registry.Variable_VentilationMonitor_IsRequestingPause  == _registry.Constant_True) || (_registry.Variable_HeatGenerationMonitor_IsRequestingPause  == _registry.Constant_True) || (_registry.Constant_DateTimeNow  < _registry.Sensor_ReadControlPanelAwayUntil))  == _registry.Constant_False);
            _logger.LogDebug("Event: Event11() (0e4a93f9-1084-4875-9e22-427a20e0a871) evaluates to {result}", result);
            return result;
        } 

        private bool Event22()
        {
            var result = (_registry.Sensor_ReadEvaporatorTemperature  > _registry.Config_HeatPumpControlConfiguration::EvaporatorTemperatureNormalDegreesCelsius);
            _logger.LogDebug("Event: Event22() (0734aeff-a9b2-43c3-9f06-462ab0181b04) evaluates to {result}", result);
            return result;
        } 

    }
}