using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swissframe.Thermos.Common.Contract;
using Swissframe.Thermos.Control.Contract.HeatPump;
using Swissframe.Thermos.Hardware.Contract;

namespace Swissframe.Util.StateEventEditor.Common.Test
{

    public class PressostatPauseMonitor
    {
        private const string Idle = nameOf(Idle);
        private const string Active = nameOf(Active);
        private const string Malfunction = nameOf(Malfunction);

        private readonly IServiceProvider _serviceProvider;
        private readonly Registry _registry;
        private readonly ILogger _logger;

        private string _currentState = [Idle];

        public PressostatPauseMonitor(IServiceProvider serviceProvider, Registry registry, ILogger logger)
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
                Active => ActiveState();
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

                    _registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset = _registry.Constant_False;

                if (Eventf38d9bb9-5a8f-4170-9bb5-3bc81c0ffcb8())
                {
                    
                    _registry.Timer_PressostatPauseMonitor_Active.Start()
                    return Active;
                }

            return Idle;
        }

        private string ActiveState()
        {

                    _registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset = _registry.Constant_False;

                if (Event8f099316-96dc-4d46-9702-0814ac17a61e())
                {
                    
                    _registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset = _registry.Constant_True;
                    // TODO implement templates
                    return Idle;
                }
                if (Event6ea8d615-2496-43ef-88da-cc68e015221b())
                {
                    
                    _registry.Variable_PressostatPauseMonitor_IsDetectingMalfunction = _registry.Constant_True;
                    // TODO implement templates
                    return Malfunction;
                }

            return Active;
        }

        private string MalfunctionState()
        {

                    _registry.Variable_PressostatPauseMonitor_IsRequestingPauseCountReset = _registry.Constant_False;


            return Malfunction;
        }



        private bool Eventf38d9bb9-5a8f-4170-9bb5-3bc81c0ffcb8()
        {
            var result = (_registry.Variable_PressostatMonitor_PauseCount  > _registry.Variable_PressostatMonitor_PauseCount);
            _logger.LogDebug("Event: Eventf38d9bb9-5a8f-4170-9bb5-3bc81c0ffcb8()(f38d9bb9-5a8f-4170-9bb5-3bc81c0ffcb8) evaluates to {result}", result);
            return result;
        } 
        private bool Event6ea8d615-2496-43ef-88da-cc68e015221b()
        {
            var result = (_registry.Variable_PressostatMonitor_PauseCount  >= _registry.Variable_PressostatMonitor_PauseCount);
            _logger.LogDebug("Event: Event6ea8d615-2496-43ef-88da-cc68e015221b()(6ea8d615-2496-43ef-88da-cc68e015221b) evaluates to {result}", result);
            return result;
        } 
        private bool Event8f099316-96dc-4d46-9702-0814ac17a61e()
        {
            var result = (_registry.Timer_PressostatPauseMonitor_Active  >= _registry.Timer_PressostatPauseMonitor_Active);
            _logger.LogDebug("Event: Event8f099316-96dc-4d46-9702-0814ac17a61e()(8f099316-96dc-4d46-9702-0814ac17a61e) evaluates to {result}", result);
            return result;
        } 
    }
}