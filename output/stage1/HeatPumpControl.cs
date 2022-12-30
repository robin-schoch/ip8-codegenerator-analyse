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

        private string _currentState = [Idle];

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

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a-1ee5-4b4e-9de3-3e8d3fda2c7a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c-71a6-445c-9c4f-467967f35749())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Eventf3013826-caaa-499e-8e63-73483faeb0b4())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_True;
                    return Normal;
                }
                if (Event8119625f-7543-4667-ad8e-71a55e2cb931())
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

                if (Event13262a8a-1ee5-4b4e-9de3-3e8d3fda2c7a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c-71a6-445c-9c4f-467967f35749())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Event7fba458b-4b48-4374-9f10-2047f5a81b31())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    return Idle;
                }
                if (Eventdd0ff77c-dc2f-4ac4-9861-8d49610599a5())
                {
                    
                    _registry.Timer_HeatPumpControl_TimerCritical1.Start()
                    return Critical_1;
                }

            return Normal;
        }

        private string Critical_1State()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a-1ee5-4b4e-9de3-3e8d3fda2c7a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c-71a6-445c-9c4f-467967f35749())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Event7fba458b-4b48-4374-9f10-2047f5a81b31())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    return Idle;
                }
                if (Event5136e5fa-6a8f-4ea6-a3a2-c0483fa1ce05())
                {
                    
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                    // TODO implement templates
                    return Normal;
                }
                if (Event2add766c-99f6-4a5f-bc2c-bf10b0bbc124())
                {
                    
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (Level2);
                    _registry.Timer_HeatPumpControl_TimerCritical2.Start()
                    return Critical_2;
                }
                if (Event6cf50e40-47f1-4d99-ab1a-aa7bfa43ebb7())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_True;
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (DefrostOrDripOff);
                    // TODO implement templates
                    return Defrost;
                }

            return Critical_1;
        }

        private string Critical_2State()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a-1ee5-4b4e-9de3-3e8d3fda2c7a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c-71a6-445c-9c4f-467967f35749())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Event7fba458b-4b48-4374-9f10-2047f5a81b31())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    return Idle;
                }
                if (Event5136e5fa-6a8f-4ea6-a3a2-c0483fa1ce05())
                {
                    
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                    // TODO implement templates
                    // TODO implement templates
                    return Normal;
                }
                if (Evente5a96ea6-6843-4a9c-b5de-6ae1a1ff4092())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_True;
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (DefrostOrDripOff);
                    // TODO implement templates
                    // TODO implement templates
                    return Defrost;
                }
                if (Event01864e49-feac-436a-97ac-31860a37ca92())
                {
                    
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (Level3);
                    return Critical_3;
                }

            return Critical_2;
        }

        private string Critical_3State()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a-1ee5-4b4e-9de3-3e8d3fda2c7a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c-71a6-445c-9c4f-467967f35749())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Event7fba458b-4b48-4374-9f10-2047f5a81b31())
                {
                    
                    // TODO implement templates
                    // TODO implement templates
                    return Idle;
                }
                if (Evente5a96ea6-6843-4a9c-b5de-6ae1a1ff4092())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_True;
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (DefrostOrDripOff);
                    // TODO implement templates
                    // TODO implement templates
                    return Defrost;
                }
                if (Eventa1619a6c-c448-49de-a93f-2bc24ca8a0ee())
                {
                    
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (Level2);
                    return Critical_2;
                }

            return Critical_3;
        }

        private string DefrostState()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a-1ee5-4b4e-9de3-3e8d3fda2c7a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c-71a6-445c-9c4f-467967f35749())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Event0734aeff-a9b2-43c3-9f06-462ab0181b04())
                {
                    
                    _registry.Timer_HeatPumpControl_TimerDripOff.Start()
                    return Drip_off;
                }

            return Defrost;
        }

        private string Drip_offState()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a-1ee5-4b4e-9de3-3e8d3fda2c7a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event7249892c-71a6-445c-9c4f-467967f35749())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Pause;
                }
                if (Event0c4189b5-76fa-4d97-bf9f-fd1653b1eee7())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_True;
                    _registry.Variable_HeatPumpControl_VentilationRequest = _registry.Constant_HeatPumpControlVentilationRequest (None);
                    // TODO implement templates
                    return Normal;
                }

            return Drip_off;
        }

        private string PauseState()
        {

                    // TODO implement templates
                    _registry.Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart = _registry.Constant_False;

                if (Event13262a8a-1ee5-4b4e-9de3-3e8d3fda2c7a())
                {
                    
                    _registry.Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring = _registry.Constant_False;
                    // TODO implement templates
                    // TODO implement templates
                    // TODO implement templates
                    return Malfunction;
                }
                if (Event0e4a93f9-1084-4875-9e22-427a20e0a871())
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



        private bool Event13262a8a-1ee5-4b4e-9de3-3e8d3fda2c7a()
        {
            var result = ((_registry.Variable_PressostatPauseMonitor_IsDetectingMalfunction  == _registry.Variable_PressostatPauseMonitor_IsDetectingMalfunction) || (_registry.Variable_VentilationPauseMonitor_IsDetectingMalfunction  == _registry.Variable_VentilationPauseMonitor_IsDetectingMalfunction) || (_registry.Variable_HeatGenerationPauseMonitor_IsDetectingMalfunction  == _registry.Variable_HeatGenerationPauseMonitor_IsDetectingMalfunction));
            _logger.LogDebug("Event: Event13262a8a-1ee5-4b4e-9de3-3e8d3fda2c7a()(13262a8a-1ee5-4b4e-9de3-3e8d3fda2c7a) evaluates to {result}", result);
            return result;
        } 
        private bool Event7249892c-71a6-445c-9c4f-467967f35749()
        {
            var result = ((_registry.Variable_PressostatMonitor_IsRequestingPause  == _registry.Variable_PressostatMonitor_IsRequestingPause) || (_registry.Variable_VentilationMonitor_IsRequestingPause  == _registry.Variable_VentilationMonitor_IsRequestingPause) || (_registry.Variable_HeatGenerationMonitor_IsRequestingPause  == _registry.Variable_HeatGenerationMonitor_IsRequestingPause) || (_registry.Constant_DateTimeNow  < _registry.Constant_DateTimeNow));
            _logger.LogDebug("Event: Event7249892c-71a6-445c-9c4f-467967f35749()(7249892c-71a6-445c-9c4f-467967f35749) evaluates to {result}", result);
            return result;
        } 
        private bool Event7fba458b-4b48-4374-9f10-2047f5a81b31()
        {
            var result = (((_registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature));
            _logger.LogDebug("Event: Event7fba458b-4b48-4374-9f10-2047f5a81b31()(7fba458b-4b48-4374-9f10-2047f5a81b31) evaluates to {result}", result);
            return result;
        } 
        private bool Eventf3013826-caaa-499e-8e63-73483faeb0b4()
        {
            var result = ((((_registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)) && (_registry.Sensor_ReadEvaporatorTemperature  >= _registry.Sensor_ReadEvaporatorTemperature));
            _logger.LogDebug("Event: Eventf3013826-caaa-499e-8e63-73483faeb0b4()(f3013826-caaa-499e-8e63-73483faeb0b4) evaluates to {result}", result);
            return result;
        } 
        private bool Event5136e5fa-6a8f-4ea6-a3a2-c0483fa1ce05()
        {
            var result = (((((_registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature))  == (((_registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature))) && (_registry.Sensor_ReadEvaporatorTemperature  >= _registry.Sensor_ReadEvaporatorTemperature));
            _logger.LogDebug("Event: Event5136e5fa-6a8f-4ea6-a3a2-c0483fa1ce05()(5136e5fa-6a8f-4ea6-a3a2-c0483fa1ce05) evaluates to {result}", result);
            return result;
        } 
        private bool Event8119625f-7543-4667-ad8e-71a55e2cb931()
        {
            var result = ((((_registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  < _registry.Sensor_ReadReservoirTemperature)) && (_registry.Sensor_ReadEvaporatorTemperature  < _registry.Sensor_ReadEvaporatorTemperature));
            _logger.LogDebug("Event: Event8119625f-7543-4667-ad8e-71a55e2cb931()(8119625f-7543-4667-ad8e-71a55e2cb931) evaluates to {result}", result);
            return result;
        } 
        private bool Eventdd0ff77c-dc2f-4ac4-9861-8d49610599a5()
        {
            var result = (((((_registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature))  == (((_registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed  == _registry.Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed) && ((((_registry.Sensor_ReadIsSelfConsumptionOptimizationRequested  == _registry.Sensor_ReadIsSelfConsumptionOptimizationRequested) || (_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel)) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)) || ((_registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel  == _registry.Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel) && (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature)))) || (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature))) && (_registry.Sensor_ReadEvaporatorTemperature  < _registry.Sensor_ReadEvaporatorTemperature));
            _logger.LogDebug("Event: Eventdd0ff77c-dc2f-4ac4-9861-8d49610599a5()(dd0ff77c-dc2f-4ac4-9861-8d49610599a5) evaluates to {result}", result);
            return result;
        } 
        private bool Event2add766c-99f6-4a5f-bc2c-bf10b0bbc124()
        {
            var result = (_registry.Sensor_ReadEvaporatorTemperature  < _registry.Sensor_ReadEvaporatorTemperature);
            _logger.LogDebug("Event: Event2add766c-99f6-4a5f-bc2c-bf10b0bbc124()(2add766c-99f6-4a5f-bc2c-bf10b0bbc124) evaluates to {result}", result);
            return result;
        } 
        private bool Eventa1619a6c-c448-49de-a93f-2bc24ca8a0ee()
        {
            var result = (_registry.Sensor_ReadEvaporatorTemperature  > _registry.Sensor_ReadEvaporatorTemperature);
            _logger.LogDebug("Event: Eventa1619a6c-c448-49de-a93f-2bc24ca8a0ee()(a1619a6c-c448-49de-a93f-2bc24ca8a0ee) evaluates to {result}", result);
            return result;
        } 
        private bool Event6cf50e40-47f1-4d99-ab1a-aa7bfa43ebb7()
        {
            var result = (_registry.Timer_HeatPumpControl_TimerCritical1  > _registry.Timer_HeatPumpControl_TimerCritical1);
            _logger.LogDebug("Event: Event6cf50e40-47f1-4d99-ab1a-aa7bfa43ebb7()(6cf50e40-47f1-4d99-ab1a-aa7bfa43ebb7) evaluates to {result}", result);
            return result;
        } 
        private bool Evente5a96ea6-6843-4a9c-b5de-6ae1a1ff4092()
        {
            var result = ((_registry.Sensor_ReadEvaporatorTemperature  <= _registry.Sensor_ReadEvaporatorTemperature) || (_registry.Timer_HeatPumpControl_TimerCritical1  > _registry.Timer_HeatPumpControl_TimerCritical1) || (_registry.Timer_HeatPumpControl_TimerCritical2  > _registry.Timer_HeatPumpControl_TimerCritical2));
            _logger.LogDebug("Event: Evente5a96ea6-6843-4a9c-b5de-6ae1a1ff4092()(e5a96ea6-6843-4a9c-b5de-6ae1a1ff4092) evaluates to {result}", result);
            return result;
        } 
        private bool Event01864e49-feac-436a-97ac-31860a37ca92()
        {
            var result = (_registry.Sensor_ReadEvaporatorTemperature  <= _registry.Sensor_ReadEvaporatorTemperature);
            _logger.LogDebug("Event: Event01864e49-feac-436a-97ac-31860a37ca92()(01864e49-feac-436a-97ac-31860a37ca92) evaluates to {result}", result);
            return result;
        } 
        private bool Event0c4189b5-76fa-4d97-bf9f-fd1653b1eee7()
        {
            var result = (_registry.Timer_HeatPumpControl_TimerDripOff  >= _registry.Timer_HeatPumpControl_TimerDripOff);
            _logger.LogDebug("Event: Event0c4189b5-76fa-4d97-bf9f-fd1653b1eee7()(0c4189b5-76fa-4d97-bf9f-fd1653b1eee7) evaluates to {result}", result);
            return result;
        } 
        private bool Event0e4a93f9-1084-4875-9e22-427a20e0a871()
        {
            var result = (((_registry.Variable_PressostatMonitor_IsRequestingPause  == _registry.Variable_PressostatMonitor_IsRequestingPause) || (_registry.Variable_VentilationMonitor_IsRequestingPause  == _registry.Variable_VentilationMonitor_IsRequestingPause) || (_registry.Variable_HeatGenerationMonitor_IsRequestingPause  == _registry.Variable_HeatGenerationMonitor_IsRequestingPause) || (_registry.Constant_DateTimeNow  < _registry.Constant_DateTimeNow))  == ((_registry.Variable_PressostatMonitor_IsRequestingPause  == _registry.Variable_PressostatMonitor_IsRequestingPause) || (_registry.Variable_VentilationMonitor_IsRequestingPause  == _registry.Variable_VentilationMonitor_IsRequestingPause) || (_registry.Variable_HeatGenerationMonitor_IsRequestingPause  == _registry.Variable_HeatGenerationMonitor_IsRequestingPause) || (_registry.Constant_DateTimeNow  < _registry.Constant_DateTimeNow)));
            _logger.LogDebug("Event: Event0e4a93f9-1084-4875-9e22-427a20e0a871()(0e4a93f9-1084-4875-9e22-427a20e0a871) evaluates to {result}", result);
            return result;
        } 
        private bool Event0734aeff-a9b2-43c3-9f06-462ab0181b04()
        {
            var result = (_registry.Sensor_ReadEvaporatorTemperature  > _registry.Sensor_ReadEvaporatorTemperature);
            _logger.LogDebug("Event: Event0734aeff-a9b2-43c3-9f06-462ab0181b04()(0734aeff-a9b2-43c3-9f06-462ab0181b04) evaluates to {result}", result);
            return result;
        } 
    }
}