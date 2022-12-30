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
        private const string Zuluft_heizen___Speicher_laden__A_ = nameof(Zuluft_heizen___Speicher_laden__A_);
        private const string Zuluft_heizen___Speicher_Bypass__B_ = nameof(Zuluft_heizen___Speicher_Bypass__B_);
        private const string Zuluft_Bypass___Speicher_laden__C_ = nameof(Zuluft_Bypass___Speicher_laden__C_);
        private const string Zuluft_Bypass___Speicher_Bypass__D_ = nameof(Zuluft_Bypass___Speicher_Bypass__D_);
        private const string Zuluft_k_hlen___Speicher_laden__E_ = nameof(Zuluft_k_hlen___Speicher_laden__E_);
        private const string Zuluft_k_hlen___Speicher_Bypass__F_ = nameof(Zuluft_k_hlen___Speicher_Bypass__F_);

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
                Zuluft_heizen___Speicher_laden__A_ => Zuluft_heizen___Speicher_laden__A_State(),
                Zuluft_heizen___Speicher_Bypass__B_ => Zuluft_heizen___Speicher_Bypass__B_State(),
                Zuluft_Bypass___Speicher_laden__C_ => Zuluft_Bypass___Speicher_laden__C_State(),
                Zuluft_Bypass___Speicher_Bypass__D_ => Zuluft_Bypass___Speicher_Bypass__D_State(),
                Zuluft_k_hlen___Speicher_laden__E_ => Zuluft_k_hlen___Speicher_laden__E_State(),
                Zuluft_k_hlen___Speicher_Bypass__F_ => Zuluft_k_hlen___Speicher_Bypass__F_State(),
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


                if (Event0f254271())
                {
                    
                    // TODO implement templates
                    return Zuluft_heizen___Speicher_Bypass__B_;
                }
                if (Event24441ac5())
                {
                    
                    // TODO implement templates
                    return Zuluft_Bypass___Speicher_laden__C_;
                }

            return Zuluft_heizen___Speicher_laden__A_;
        }

        private string Zuluft_heizen___Speicher_Bypass__B_State()
        {


                if (Event6700be5e())
                {
                    
                    // TODO implement templates
                    return Zuluft_heizen___Speicher_laden__A_;
                }
                if (Event24441ac5())
                {
                    
                    // TODO implement templates
                    return Zuluft_Bypass___Speicher_Bypass__D_;
                }

            return Zuluft_heizen___Speicher_Bypass__B_;
        }

        private string Zuluft_Bypass___Speicher_laden__C_State()
        {


                if (Event0f254271())
                {
                    
                    // TODO implement templates
                    return Zuluft_Bypass___Speicher_Bypass__D_;
                }
                if (Event7cfd71e9())
                {
                    
                    // TODO implement templates
                    return Zuluft_heizen___Speicher_laden__A_;
                }
                if (Event24441ac5())
                {
                    
                    // TODO implement templates
                    return Zuluft_k_hlen___Speicher_laden__E_;
                }

            return Zuluft_Bypass___Speicher_laden__C_;
        }

        private string Zuluft_Bypass___Speicher_Bypass__D_State()
        {


                if (Event6700be5e())
                {
                    
                    // TODO implement templates
                    return Zuluft_Bypass___Speicher_laden__C_;
                }
                if (Event7cfd71e9())
                {
                    
                    // TODO implement templates
                    return Zuluft_heizen___Speicher_Bypass__B_;
                }
                if (Event24441ac5())
                {
                    
                    // TODO implement templates
                    return Zuluft_k_hlen___Speicher_Bypass__F_;
                }

            return Zuluft_Bypass___Speicher_Bypass__D_;
        }

        private string Zuluft_k_hlen___Speicher_laden__E_State()
        {


                if (Event0f254271())
                {
                    
                    // TODO implement templates
                    return Zuluft_k_hlen___Speicher_Bypass__F_;
                }
                if (Event7cfd71e9())
                {
                    
                    // TODO implement templates
                    return Zuluft_Bypass___Speicher_laden__C_;
                }

            return Zuluft_k_hlen___Speicher_laden__E_;
        }

        private string Zuluft_k_hlen___Speicher_Bypass__F_State()
        {


                if (Event6700be5e())
                {
                    
                    // TODO implement templates
                    return Zuluft_k_hlen___Speicher_laden__E_;
                }
                if (Event7cfd71e9())
                {
                    
                    // TODO implement templates
                    return Zuluft_Bypass___Speicher_Bypass__D_;
                }

            return Zuluft_k_hlen___Speicher_Bypass__F_;
        }



        private bool Event0f254271()
        {
            var result = (_registry.Sensor_ReadReservoirTemperature  >= _registry.Sensor_ReadReservoirTemperature);
            _logger.LogDebug("Event: Event0f254271() evaluates to {result}", result);
            return result;
        } 
        private bool Event6700be5e()
        {
            var result = (_registry.Sensor_ReadReservoirTemperature  <= _registry.Sensor_ReadReservoirTemperature);
            _logger.LogDebug("Event: Event6700be5e() evaluates to {result}", result);
            return result;
        } 
        private bool Event7cfd71e9()
        {
            var result = (_registry.Sensor_ReadExhaustFanTemperatureAir  <= _registry.Sensor_ReadExhaustFanTemperatureAir);
            _logger.LogDebug("Event: Event7cfd71e9() evaluates to {result}", result);
            return result;
        } 
        private bool Event24441ac5()
        {
            var result = (_registry.Sensor_ReadExhaustFanTemperatureAir  >= _registry.Sensor_ReadExhaustFanTemperatureAir);
            _logger.LogDebug("Event: Event24441ac5() evaluates to {result}", result);
            return result;
        } 
    }
}