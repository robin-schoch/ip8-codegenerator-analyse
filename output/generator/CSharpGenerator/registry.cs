using System;
using Swissframe.Thermos.Common.Contract;
using Swissframe.Thermos.Control.Contract.HeatPump;

namespace Swissframe.Util.StateEventEditor.Common.Test
{
    public class Registry
    {
        public double Config_ClimateControlConfiguration__ReservoirTemperatureAboveThresholdDegreesCelsius { get; set; } 
        public double Config_ClimateControlConfiguration__ReservoirTemperatureBelowThresholdDegreesCelsius { get; set; } 
        public double Config_ClimateControlConfiguration__ExhaustAirTemperatureBelowThresholdDegreesCelsius { get; set; } 
        public double Config_ClimateControlConfiguration__ExhaustAirTemperatureAboveThresholdDegreesCelsius { get; set; } 
        // TODO implement list properties GeneralConfiguration::SystemType a51a258a-f263-40c9-b14e-b7c8b65b4525
        public uint Config_HeatPumpControlConfiguration__Critical1MaximumTimeMinutes { get; set; } 
        public uint Config_HeatPumpControlConfiguration__Critical2MaximumTimeMinutes { get; set; } 
        public uint Config_HeatPumpControlConfiguration__DripOffTimeMinutes { get; set; } 
        public double Config_HeatPumpControlConfiguration__EvaporatorTemperatureCritical1DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration__EvaporatorTemperatureCritical2DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration__EvaporatorTemperatureCritical3DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration__EvaporatorTemperatureMinimumDegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration__EvaporatorTemperatureNormalDegreesCelsius { get; set; } 
        public bool Config_HeatPumpControlConfiguration__IsSelfConsumptionOptimizationAllowed { get; set; } 
        public uint Config_HeatPumpControlConfiguration__SelfConsumptionOptimizationLevel { get; set; } 
        public double Config_HeatPumpControlConfiguration__ReservoirTemperatureMaximumNormalDegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration__ReservoirTemperatureMinimumNormalDegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration__ReservoirTemperatureMaximumScoL1DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration__ReservoirTemperatureMinimumScoL1DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration__ReservoirTemperatureMaximumScoL2DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration__ReservoirTemperatureMinimumScoL2DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration__ReservoirTemperatureMaximumScoL3DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration__ReservoirTemperatureMinimumScoL3DegreesCelsius { get; set; } 
        public uint Config_PressostatControlConfiguration__PauseDurationMinutes { get; set; } 
        public double Config_PressostatControlConfiguration__HeatGenerationTemperatureReductionPerPauseCount { get; set; } 
        public uint Config_PressostatControlConfiguration__MaximumPauseCount { get; set; } 
        public uint Config_PressostatMonitorConfiguration__DebounceDurationSeconds { get; set; } 
        public uint Config_PressostatMonitorConfiguration__MaximumActiveDurationMinutes { get; set; } 
        public uint Config_PressostatMonitorConfiguration__MaximumOverpressureCount { get; set; } 
        public uint Config_PressostatMonitorConfiguration__MaximumPauseDurationMinutes { get; set; } 
        public uint Config_PressostatPauseMonitorConfiguration__MaximumActiveDurationHours { get; set; } 
        public uint Config_PressostatPauseMonitorConfiguration__MaximumPauseCount { get; set; } 
        public DateTime Constant_DateTimeNow { get; set;} 
        public bool Constant_True { get; set; } 
        public bool Constant_False { get; set; } 
        // TODO implement list properties SystemType (Thermos2) 9b8af4c5-9ced-42ac-9f48-2816caa49d1a
        // TODO implement list properties SystemType (Thermos3) b2144c0f-b4cb-4fc8-aacf-5b3df107d6da
        // TODO implement list properties SystemType (Varios) 4f27400f-9587-492b-ad70-9093cd2b41ae
        public HeatPumpControlVentilationRequest Constant_HeatPumpControlVentilationRequest__None_ { get; set; }
        public HeatPumpControlVentilationRequest Constant_HeatPumpControlVentilationRequest__Level2_ { get; set; }
        public HeatPumpControlVentilationRequest Constant_HeatPumpControlVentilationRequest__Level3_ { get; set; }
        public HeatPumpControlVentilationRequest Constant_HeatPumpControlVentilationRequest__DefrostOrDripOff_ { get; set; }
        public double Sensor_ReadEvaporatorTemperature { get; set; } 
        public double Sensor_ReadReservoirTemperature { get; set; } 
        public double Sensor_ReadExhaustAirAfterHeatExchangerTemperature { get; set; } 
        public double Sensor_ReadExhaustAirBeforeHeatExchangerTemperature { get; set; } 
        public double Sensor_ReadInletAirAfterHeatExchangerTemperature { get; set; } 
        public bool Sensor_ReadIsHeatPumpOverpressureTriggeredWithClearAfterRead { get; set; } 
        public bool Sensor_ReadIsSelfConsumptionOptimizationRequested { get; set; } 
        public double Sensor_ReadExhaustFanHumidity { get; set; } 
        public double Sensor_ReadExhaustFanRpm { get; set; } 
        public double Sensor_ReadExhaustFanTemperatureAir { get; set; } 
        public double Sensor_ReadInletFanHumidity { get; set; } 
        public double Sensor_ReadInletFanRpm { get; set; } 
        public double Sensor_ReadInletFanTemperatureAir { get; set; } 
        public double Sensor_ReadHighPressureSensorPressure { get; set; } 
        public double Sensor_ReadLowPressureSensorPressure { get; set; } 
        public double Sensor_ReadFlowHeaterDesiredTemp { get; set; } 
        public DateTime Sensor_ReadControlPanelAwayUntil { get; set;} 
        public double Sensor_ReadCompressorTemperature { get; set; } 
        public double Sensor_ReadColdwaterSupplyJouliaThermometer { get; set; } 
        public double Sensor_ReadColdwaterSupplyThermosThermometer { get; set; } 
        public double Sensor_ReadFacadeInletTemperature { get; set; } 
        public double Sensor_ReadFacadeOutletTemperature { get; set; } 
        public ITimer Timer_PressostatMonitor_Debounce { get; } 
        public ITimer Timer_PressostatMonitor_Active { get; } 
        public ITimer Timer_PressostatMonitor_Pause { get; } 
        public int Variable_PressostatMonitor_OverpressureCount { get; set; }  = 0;
        public int Variable_PressostatMonitor_PauseCount { get; set; }  = 0;
        public bool Variable_PressostatMonitor_IsRequestingPause { get; set; }  = false;
        public bool Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop { get; set; }  = false;
        public bool Variable_PressostatPauseMonitor_IsDetectingMalfunction { get; set; }  = false;
        public bool Variable_PressostatPauseMonitor_IsRequestingPauseCountReset { get; set; }  = false;
        public int Constant_One { get; set; }  = 1;
        public ITimer Timer_PressostatPauseMonitor_Active { get; } 
        public int Constant_Zero { get; set; }  = 0;
        public ITimer Timer_HeatPumpControl_TimerCritical1 { get; } 
        public ITimer Timer_HeatPumpControl_TimerCritical2 { get; } 
        public ITimer Timer_HeatPumpControl_TimerDripOff { get; } 
        public HeatPumpControlVentilationRequest Variable_HeatPumpControl_VentilationRequest { get; set; }
        public bool Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring { get; set; }  = false;
        public bool Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart { get; set; }  = false;
        public bool Variable_VentilationPauseMonitor_IsDetectingMalfunction { get; set; }  = false;
        public bool Variable_HeatGenerationPauseMonitor_IsDetectingMalfunction { get; set; }  = false;
        public bool Variable_VentilationMonitor_IsRequestingPause { get; set; }  = false;
        public bool Variable_HeatGenerationMonitor_IsRequestingPause { get; set; }  = false;
        public int Constant_Two { get; set; }  = 2;
        public int Constant_Three { get; set; }  = 3;
        public ITimer Timer_PressostatControl_Pause { get; } 
        public bool Variable_PressostatControl_IsRequestingHeatPumpPause { get; set; }  = false;
        public uint Variable_PressostatControl_OverpressureCount { get; set; }  = 0;
        public bool Variable_PressostatControl_IsRequestingHeatPumpMonitoringStop { get; set; }  = false;
        public uint Variable_PressostatControl_PauseCount { get; set; }  = 0;
    }
}