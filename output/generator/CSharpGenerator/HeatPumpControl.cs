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
        private const string Idle = nameof(Idle);
        private const string Normal = nameof(Normal);
        private const string Critical_1 = nameof(Critical_1);
        private const string Critical_2 = nameof(Critical_2);
        private const string Critical_3 = nameof(Critical_3);
        private const string Defrost = nameof(Defrost);
        private const string Drip_off = nameof(Drip_off);
        private const string Pause = nameof(Pause);
        private const string Malfunction = nameof(Malfunction);

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
                Idle => IdleState(),
                Normal => NormalState(),
                Critical_1 => Critical_1State(),
                Critical_2 => Critical_2State(),
                Critical_3 => Critical_3State(),
                Defrost => DefrostState(),
                Drip_off => Drip_offState(),
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

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__None_;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Eventf3013826())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_True;
                    return Normal;
                }
                if (Event8119625f())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_True;
                    return Critical_1;
                }

            return Idle;
        }

        private string NormalState()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__None_;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Event7fba458b())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    return Idle;
                }
                if (Eventdd0ff77c())
                {
                    
                    _registry.Timer_HeatPumpControl_TimerCritical1.Start();
                    return Critical_1;
                }

            return Normal;
        }

        private string Critical_1State()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__None_;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Event7fba458b())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    return Idle;
                }
                if (Event5136e5fa())
                {
                    
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__None_;
                    // TODO implement templates
                    return Normal;
                }
                if (Event2add766c())
                {
                    
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__Level2_;
                    _registry.Timer_HeatPumpControl_TimerCritical2.Start();
                    return Critical_2;
                }
                if (Event6cf50e40())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_True;
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__DefrostOrDripOff_;
                    // TODO implement templates
                    return Defrost;
                }

            return Critical_1;
        }

        private string Critical_2State()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__None_;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Event7fba458b())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    return Idle;
                }
                if (Event5136e5fa())
                {
                    
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__None_;
                    // TODO implement templates
                    // TODO implement templates
                    return Normal;
                }
                if (Evente5a96ea6())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_True;
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__DefrostOrDripOff_;
                    // TODO implement templates
                    // TODO implement templates
                    return Defrost;
                }
                if (Event01864e49())
                {
                    
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__Level3_;
                    return Critical_3;
                }

            return Critical_2;
        }

        private string Critical_3State()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__None_;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Event7fba458b())
                {
                    
                    // TODO implement templates
                    // TODO implement templates
                    return Idle;
                }
                if (Evente5a96ea6())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_True;
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__DefrostOrDripOff_;
                    // TODO implement templates
                    // TODO implement templates
                    return Defrost;
                }
                if (Eventa1619a6c())
                {
                    
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__Level2_;
                    return Critical_2;
                }

            return Critical_3;
        }

        private string DefrostState()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__None_;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Event0734aeff())
                {
                    
                    _registry.Timer_HeatPumpControl_TimerDripOff.Start();
                    return Drip_off;
                }

            return Defrost;
        }

        private string Drip_offState()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__None_;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Event0c4189b5())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_True;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest__None_;
                    // TODO implement templates
                    return Normal;
                }

            return Drip_off;
        }

        private string PauseState()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event0e4a93f9())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_True;
                    return Normal;
                }

            return Pause;
        }

        private string MalfunctionState()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;


            return Malfunction;
        }



        private bool Event13262a8a()
        {
            var result = ((_registry.Variable_PressostatPauseMonitor_IsDetectingMalfunction  == _registry.Variable_PressostatPauseMonitor_IsDetectingMalfunction) || (_registry.Variable_VentilationPauseMonitor_IsDetectingMalfunction  == _registry.Variable_VentilationPauseMonitor_IsDetectingMalfunction) || (_registry.Variable_HeatGenerationPauseMonitor_IsDetectingMalfunction  == _registry.Variable_HeatGenerationPauseMonitor_IsDetectingMalfunction));
            _logger.LogDebug("Event: Event13262a8a() evaluates to {result}", result);
            return result;
        } 
        private bool Event7249892c()
        {
            var result = ((_registry.Variable_PressostatMonitor_IsRequestingPause  == _registry.Variable_PressostatMonitor_IsRequestingPause) || (_registry.Variable_VentilationMonitor_IsRequestingPause  == _registry.Variable_VentilationMonitor_IsRequestingPause) || (_registry.Variable_HeatGenerationMonitor_IsRequestingPause  == _registry.Variable_HeatGenerationMonitor_IsRequestingPause) || (_registry.Constant_DateTimeNow  < _registry.Constant_DateTimeNow));
            _logger.LogDebug("Event: Event7249892c() evaluates to {result}", result);
            return result;
        } 
        private bool Event7fba458b()
        {
            var result = (((_registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature));
            _logger.LogDebug("Event: Event7fba458b() evaluates to {result}", result);
            return result;
        } 
        private bool Eventf3013826()
        {
            var result = ((((_registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)) && (_registry.Sensor_ReadEvaporatorTemperature  >= _registry.Sensor_ReadEvaporatorTemperature));
            _logger.LogDebug("Event: Eventf3013826() evaluates to {result}", result);
            return result;
        } 
        private bool Event5136e5fa()
        {
            var result = (((((_registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature))  == (((_registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature))) && (_registry.Sensor_ReadEvaporatorTemperature  >= _registry.Sensor_ReadEvaporatorTemperature));
            _logger.LogDebug("Event: Event5136e5fa() evaluates to {result}", result);
            return result;
        } 
        private bool Event8119625f()
        {
            var result = ((((_registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)) && (_registry.Sensor_ReadEvaporatorTemperature  < _registry.Sensor_ReadEvaporatorTemperature));
            _logger.LogDebug("Event: Event8119625f() evaluates to {result}", result);
            return result;
        } 
        private bool Eventdd0ff77c()
        {
            var result = (((((_registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature))  == (((_registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature))) && (_registry.Sensor_ReadEvaporatorTemperature  < _registry.Sensor_ReadEvaporatorTemperature));
            _logger.LogDebug("Event: Eventdd0ff77c() evaluates to {result}", result);
            return result;
        } 
        private bool Event2add766c()
        {
            var result = (_registry.Sensor_ReadEvaporatorTemperature  < _registry.Sensor_ReadEvaporatorTemperature);
            _logger.LogDebug("Event: Event2add766c() evaluates to {result}", result);
            return result;
        } 
        private bool Eventa1619a6c()
        {
            var result = (_registry.Sensor_ReadEvaporatorTemperature  > _registry.Sensor_ReadEvaporatorTemperature);
            _logger.LogDebug("Event: Eventa1619a6c() evaluates to {result}", result);
            return result;
        } 
        private bool Event6cf50e40()
        {
            var result = (_registry.Timer_HeatPumpControl_TimerCritical1  > _registry.Timer_HeatPumpControl_TimerCritical1);
            _logger.LogDebug("Event: Event6cf50e40() evaluates to {result}", result);
            return result;
        } 
        private bool Evente5a96ea6()
        {
            var result = ((_registry.Sensor_ReadEvaporatorTemperature  <= _registry.Sensor_ReadEvaporatorTemperature) || (_registry.Timer_HeatPumpControl_TimerCritical1  > _registry.Timer_HeatPumpControl_TimerCritical1) || (_registry.Timer_HeatPumpControl_TimerCritical2  > _registry.Timer_HeatPumpControl_TimerCritical2));
            _logger.LogDebug("Event: Evente5a96ea6() evaluates to {result}", result);
            return result;
        } 
        private bool Event01864e49()
        {
            var result = (_registry.Sensor_ReadEvaporatorTemperature  <= _registry.Sensor_ReadEvaporatorTemperature);
            _logger.LogDebug("Event: Event01864e49() evaluates to {result}", result);
            return result;
        } 
        private bool Event0c4189b5()
        {
            var result = (_registry.Timer_HeatPumpControl_TimerDripOff  >= _registry.Timer_HeatPumpControl_TimerDripOff);
            _logger.LogDebug("Event: Event0c4189b5() evaluates to {result}", result);
            return result;
        } 
        private bool Event0e4a93f9()
        {
            var result = (((_registry.Variable_PressostatMonitor_IsRequestingPause  == _registry.Variable_PressostatMonitor_IsRequestingPause) || (_registry.Variable_VentilationMonitor_IsRequestingPause  == _registry.Variable_VentilationMonitor_IsRequestingPause) || (_registry.Variable_HeatGenerationMonitor_IsRequestingPause  == _registry.Variable_HeatGenerationMonitor_IsRequestingPause) || (_registry.Constant_DateTimeNow  < _registry.Constant_DateTimeNow))  == ((_registry.Variable_PressostatMonitor_IsRequestingPause  == _registry.Variable_PressostatMonitor_IsRequestingPause) || (_registry.Variable_VentilationMonitor_IsRequestingPause  == _registry.Variable_VentilationMonitor_IsRequestingPause) || (_registry.Variable_HeatGenerationMonitor_IsRequestingPause  == _registry.Variable_HeatGenerationMonitor_IsRequestingPause) || (_registry.Constant_DateTimeNow  < _registry.Constant_DateTimeNow)));
            _logger.LogDebug("Event: Event0e4a93f9() evaluates to {result}", result);
            return result;
        } 
        private bool Event0734aeff()
        {
            var result = (_registry.Sensor_ReadEvaporatorTemperature  > _registry.Sensor_ReadEvaporatorTemperature);
            _logger.LogDebug("Event: Event0734aeff() evaluates to {result}", result);
            return result;
        } 
    }
}