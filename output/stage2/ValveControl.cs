using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swissframe.Thermos.Common.Contract;
using Swissframe.Thermos.Control.Contract.HeatPump;
using Swissframe.Thermos.Hardware.Contract;

namespace Swissframe.Util.StateEventEditor.Common.Test
{

    public class ValveControl
    {
        private const string Zuluft_heizen___Speicher_laden__A_ = nameOf(Zuluft_heizen___Speicher_laden__A_);
        private const string Zuluft_heizen___Speicher_Bypass__B_ = nameOf(Zuluft_heizen___Speicher_Bypass__B_);
        private const string Zuluft_Bypass___Speicher_laden__C_ = nameOf(Zuluft_Bypass___Speicher_laden__C_);
        private const string Zuluft_Bypass___Speicher_Bypass__D_ = nameOf(Zuluft_Bypass___Speicher_Bypass__D_);
        private const string Zuluft_k_hlen___Speicher_laden__E_ = nameOf(Zuluft_k_hlen___Speicher_laden__E_);
        private const string Zuluft_k_hlen___Speicher_Bypass__F_ = nameOf(Zuluft_k_hlen___Speicher_Bypass__F_);

        private readonly IServiceProvider _serviceProvider;
        private readonly Registry _registry;
        private readonly ILogger _logger;

        private string _currentState = Zuluft_heizen___Speicher_laden__A_;

        public ValveControl(IServiceProvider serviceProvider, Registry registry, ILogger logger)
        {
            _serviceProvider = serviceProvider;
            _registry = registry;
            _logger = logger;
        }

        public void UpdateState()
        {
            var nextState = _currentState switch
            {
                Zuluft_heizen___Speicher_laden__A_ => Zuluft_heizen___Speicher_laden__A_State();
                Zuluft_heizen___Speicher_Bypass__B_ => Zuluft_heizen___Speicher_Bypass__B_State();
                Zuluft_Bypass___Speicher_laden__C_ => Zuluft_Bypass___Speicher_laden__C_State();
                Zuluft_Bypass___Speicher_Bypass__D_ => Zuluft_Bypass___Speicher_Bypass__D_State();
                Zuluft_k_hlen___Speicher_laden__E_ => Zuluft_k_hlen___Speicher_laden__E_State();
                Zuluft_k_hlen___Speicher_Bypass__F_ => Zuluft_k_hlen___Speicher_Bypass__F_State();
                _ => throw new ArgumentOutOfRangeException()
            };

            if (nextState != _currentState)
            {
                _logger.LogInformation("perform transition from {source} to {target}", _currentState, nextState);
            }
            _currentState = nextState;
        }

        private string Zuluft_heizen___Speicher_laden__A_State()
        {
            

            if (Event24())
            {
                
                TODO()
                return Zuluft_heizen___Speicher_Bypass__B_;
            }

            if (Event27())
            {
                
                TODO()
                return Zuluft_Bypass___Speicher_laden__C_;
            }


            return Zuluft_heizen___Speicher_laden__A_;
        }
        private string Zuluft_heizen___Speicher_Bypass__B_State()
        {
            

            if (Event25())
            {
                
                TODO()
                return Zuluft_heizen___Speicher_laden__A_;
            }

            if (Event27())
            {
                
                TODO()
                return Zuluft_Bypass___Speicher_Bypass__D_;
            }


            return Zuluft_heizen___Speicher_Bypass__B_;
        }
        private string Zuluft_Bypass___Speicher_laden__C_State()
        {
            

            if (Event24())
            {
                
                TODO()
                return Zuluft_Bypass___Speicher_Bypass__D_;
            }

            if (Event26())
            {
                
                TODO()
                return Zuluft_heizen___Speicher_laden__A_;
            }

            if (Event27())
            {
                
                TODO()
                return Zuluft_k_hlen___Speicher_laden__E_;
            }


            return Zuluft_Bypass___Speicher_laden__C_;
        }
        private string Zuluft_Bypass___Speicher_Bypass__D_State()
        {
            

            if (Event25())
            {
                
                TODO()
                return Zuluft_Bypass___Speicher_laden__C_;
            }

            if (Event26())
            {
                
                TODO()
                return Zuluft_heizen___Speicher_Bypass__B_;
            }

            if (Event27())
            {
                
                TODO()
                return Zuluft_k_hlen___Speicher_Bypass__F_;
            }


            return Zuluft_Bypass___Speicher_Bypass__D_;
        }
        private string Zuluft_k_hlen___Speicher_laden__E_State()
        {
            

            if (Event24())
            {
                
                TODO()
                return Zuluft_k_hlen___Speicher_Bypass__F_;
            }

            if (Event26())
            {
                
                TODO()
                return Zuluft_Bypass___Speicher_laden__C_;
            }


            return Zuluft_k_hlen___Speicher_laden__E_;
        }
        private string Zuluft_k_hlen___Speicher_Bypass__F_State()
        {
            

            if (Event25())
            {
                
                TODO()
                return Zuluft_k_hlen___Speicher_laden__E_;
            }

            if (Event26())
            {
                
                TODO()
                return Zuluft_Bypass___Speicher_Bypass__D_;
            }


            return Zuluft_k_hlen___Speicher_Bypass__F_;
        }

        private bool Event24()
        {
            var result = (_registry.Sensor_ReadReservoirTemperature  >= _registry.Config_ClimateControlConfiguration::ReservoirTemperatureAboveThresholdDegreesCelsius);
            _logger.LogDebug("Event: Event24() (0f254271-f87b-4ea9-b1ab-39ca36d3562a) evaluates to {result}", result);
            return result;
        } 

        private bool Event25()
        {
            var result = (_registry.Sensor_ReadReservoirTemperature  <= _registry.Config_ClimateControlConfiguration::ReservoirTemperatureBelowThresholdDegreesCelsius);
            _logger.LogDebug("Event: Event25() (6700be5e-1f0b-437e-b3cd-814f32e1e381) evaluates to {result}", result);
            return result;
        } 

        private bool Event26()
        {
            var result = (_registry.Sensor_ReadExhaustFanTemperatureAir  <= _registry.Config_ClimateControlConfiguration::ExhaustAirTemperatureAboveThresholdDegreesCelsius);
            _logger.LogDebug("Event: Event26() (7cfd71e9-feff-4efc-a6c0-a1a25beb6a05) evaluates to {result}", result);
            return result;
        } 

        private bool Event27()
        {
            var result = (_registry.Sensor_ReadExhaustFanTemperatureAir  >= _registry.Config_ClimateControlConfiguration::ExhaustAirTemperatureBelowThresholdDegreesCelsius);
            _logger.LogDebug("Event: Event27() (24441ac5-316d-4310-b99d-491f81cdb431) evaluates to {result}", result);
            return result;
        } 

    }
}