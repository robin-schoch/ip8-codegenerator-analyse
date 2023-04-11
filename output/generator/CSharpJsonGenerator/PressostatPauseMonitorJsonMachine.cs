using System;
using Microsoft.Extensions.Logging;
using Swissframe.Util.StateEventEditor.Common.Builder;

namespace Swissframe.Util.StateEventEditor.Common.Test
{
    public class PressostatPauseMonitor
    {
        private const string Idle = "4c7e137b-e231-47c9-9af4-469f4800122c";
        private const string Active = "cf8619db-e3ec-4ce2-9ea0-bd9c5b6bd372";
        private const string Malfunction = "9cede9c7-883e-4fc5-ab0f-bffbbff32eb6";

        private readonly IRegistry _registry;
        private readonly ILogger _logger;

        private string _currentState = Idle;

        public PressostatPauseMonitor(IRegistry registry, ILogger logger)
        {
            _registry = registry;
            _logger = logger;
        }

        public void UpdateState()
        {
            var nextState = _currentState switch
            {
                Idle => IdleState(),
                Active => ActiveState(),
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
            _registry.GetInvocation("ae93dcac-96eb-4656-888a-0fc611d5e888", _logger)();

            if (event0())
            {
                _registry.GetInvocation("7a784ed1-9569-4363-a658-6e020db664e0", _logger)();

                return Active;
            }
        return Idle;
        }

        private string ActiveState()
        {
            _registry.GetInvocation("ae93dcac-96eb-4656-888a-0fc611d5e888", _logger)();

            if (event2())
            {
                _registry.GetInvocation("f26639a8-c7f1-4847-8549-b3f87495dbc2", _logger)();
                _registry.GetInvocation("538c45ac-2517-47bf-9516-ba7dffa29979", _logger)();

                return Idle;
            }
            if (event1())
            {
                _registry.GetInvocation("f26639a8-c7f1-4847-8549-b3f87495dbc2", _logger)();
                _registry.GetInvocation("485cccdd-5247-4f3d-9e10-2443a9260506", _logger)();

                return Malfunction;
            }
        return Active;
        }

        private string MalfunctionState()
        {
            _registry.GetInvocation("ae93dcac-96eb-4656-888a-0fc611d5e888", _logger)();

        return Malfunction;
        }

        private bool event0()
        {
            return _registry.GetCheck("530d864c-c6f5-40f3-9e9c-42df4035aa0c", _logger)();
        }

        private bool event1()
        {
            return _registry.GetCheck("3f86d5c0-31b9-4129-bf51-18f656fb9e82", _logger)();
        }

        private bool event2()
        {
            return _registry.GetCheck("cba80ee5-74db-47c5-aad5-28bda4f87c63", _logger)();
        }

    }
}