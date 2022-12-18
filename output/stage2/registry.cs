namespace Swissframe.Util.StateEventEditor.Common.Test
{
    class Registry
    {
        public double Config_ClimateControlConfiguration::ReservoirTemperatureAboveThresholdDegreesCelsius { get; set; } 
        public double Config_ClimateControlConfiguration::ReservoirTemperatureBelowThresholdDegreesCelsius { get; set; } 
        public double Config_ClimateControlConfiguration::ExhaustAirTemperatureBelowThresholdDegreesCelsius { get; set; } 
        public double Config_ClimateControlConfiguration::ExhaustAirTemperatureAboveThresholdDegreesCelsius { get; set; } 
        public uint Config_HeatPumpControlConfiguration::Critical1MaximumTimeMinutes { get; set; } 
        public uint Config_HeatPumpControlConfiguration::Critical2MaximumTimeMinutes { get; set; } 
        public uint Config_HeatPumpControlConfiguration::DripOffTimeMinutes { get; set; } 
        public double Config_HeatPumpControlConfiguration::EvaporatorTemperatureCritical1DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration::EvaporatorTemperatureCritical2DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration::EvaporatorTemperatureCritical3DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration::EvaporatorTemperatureMinimumDegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration::EvaporatorTemperatureNormalDegreesCelsius { get; set; } 
        public bool Config_HeatPumpControlConfiguration::IsSelfConsumptionOptimizationAllowed} { get; set; } 
        public uint Config_HeatPumpControlConfiguration::SelfConsumptionOptimizationLevel { get; set; } 
        public double Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumNormalDegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration::ReservoirTemperatureMinimumNormalDegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumScoL1DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration::ReservoirTemperatureMinimumScoL1DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumScoL2DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration::ReservoirTemperatureMinimumScoL2DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration::ReservoirTemperatureMaximumScoL3DegreesCelsius { get; set; } 
        public double Config_HeatPumpControlConfiguration::ReservoirTemperatureMinimumScoL3DegreesCelsius { get; set; } 
        public uint Config_PressostatControlConfiguration::PauseDurationMinutes { get; set; } 
        public double Config_PressostatControlConfiguration::HeatGenerationTemperatureReductionPerPauseCount { get; set; } 
        public uint Config_PressostatControlConfiguration::MaximumPauseCount { get; set; } 
        public uint Config_PressostatMonitorConfiguration::DebounceDurationSeconds { get; set; } 
        public uint Config_PressostatMonitorConfiguration::MaximumActiveDurationMinutes { get; set; } 
        public uint Config_PressostatMonitorConfiguration::MaximumOverpressureCount { get; set; } 
        public uint Config_PressostatMonitorConfiguration::MaximumPauseDurationMinutes { get; set; } 
        public uint Config_PressostatPauseMonitorConfiguration::MaximumActiveDurationHours { get; set; } 
        public uint Config_PressostatPauseMonitorConfiguration::MaximumPauseCount { get; set; } 
        TODO()
        public bool Constant_True} { get; set; } 
        public bool Constant_False} { get; set; } 
        TODO()
        TODO()
        TODO()
        public HeapPump Constant_HeatPumpControlVentilationRequest (None) { get; set; }
        public HeapPump Constant_HeatPumpControlVentilationRequest (Level2) { get; set; }
        public HeapPump Constant_HeatPumpControlVentilationRequest (Level3) { get; set; }
        public HeapPump Constant_HeatPumpControlVentilationRequest (DefrostOrDripOff) { get; set; }
        public double Sensor_ReadEvaporatorTemperature { get; set; } 
        public double Sensor_ReadReservoirTemperature { get; set; } 
        public double Sensor_ReadExhaustAirAfterHeatExchangerTemperature { get; set; } 
        public double Sensor_ReadExhaustAirBeforeHeatExchangerTemperature { get; set; } 
        public double Sensor_ReadInletAirAfterHeatExchangerTemperature { get; set; } 
        public bool Sensor_ReadIsHeatPumpOverpressureTriggeredWithClearAfterRead} { get; set; } 
        public bool Sensor_ReadIsSelfConsumptionOptimizationRequested} { get; set; } 
        public double Sensor_ReadExhaustFanHumidity { get; set; } 
        public double Sensor_ReadExhaustFanRpm { get; set; } 
        public double Sensor_ReadExhaustFanTemperatureAir { get; set; } 
        public double Sensor_ReadInletFanHumidity { get; set; } 
        public double Sensor_ReadInletFanRpm { get; set; } 
        public double Sensor_ReadInletFanTemperatureAir { get; set; } 
        public double Sensor_ReadHighPressureSensorPressure { get; set; } 
        public double Sensor_ReadLowPressureSensorPressure { get; set; } 
        public double Sensor_ReadFlowHeaterDesiredTemp { get; set; } 
        TODO()
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
        public bool Variable_PressostatMonitor_IsRequestingPause} { get; set; }  = false;
        public bool Variable_PressostatMonitor_IsRequestingHeatPumpMonitoringStop} { get; set; }  = false;
        public bool Variable_PressostatPauseMonitor_IsDetectingMalfunction} { get; set; }  = false;
        public bool Variable_PressostatPauseMonitor_IsRequestingPauseCountReset} { get; set; }  = false;
        public int Constant_One { get; set; }  = 1;
        public ITimer Timer_PressostatPauseMonitor_Active { get; } 
        public int Constant_Zero { get; set; }  = 0;
        public ITimer Timer_HeatPumpControl_TimerCritical1 { get; } 
        public ITimer Timer_HeatPumpControl_TimerCritical2 { get; } 
        public ITimer Timer_HeatPumpControl_TimerDripOff { get; } 
        public HeapPump Variable_HeatPumpControl_VentilationRequest { get; set; }
        public bool Variable_HeatPumpControl_IsRequestingHeatPumpMonitoring} { get; set; }  = false;
        public bool Variable_HeatPumpControl_IsRequestingVentilationMonitoringStart} { get; set; }  = false;
        public bool Variable_VentilationPauseMonitor_IsDetectingMalfunction} { get; set; }  = false;
        public bool Variable_HeatGenerationPauseMonitor_IsDetectingMalfunction} { get; set; }  = false;
        public bool Variable_VentilationMonitor_IsRequestingPause} { get; set; }  = false;
        public bool Variable_HeatGenerationMonitor_IsRequestingPause} { get; set; }  = false;
        public int Constant_Two { get; set; }  = 2;
        public int Constant_Three { get; set; }  = 3;
        public ITimer Timer_PressostatControl_Pause { get; } 
        public bool Variable_PressostatControl_IsRequestingHeatPumpPause} { get; set; }  = false;
        public uint Variable_PressostatControl_OverpressureCount { get; set; }  = 0;
        public bool Variable_PressostatControl_IsRequestingHeatPumpMonitoringStop} { get; set; }  = false;
        public uint Variable_PressostatControl_PauseCount { get; set; }  = 0;
        TODO()
    }
}