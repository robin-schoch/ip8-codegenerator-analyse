using System;
using Microsoft.Extensions.Logging;
using Swissframe.Util.StateEventEditor.Common.Builder;

namespace Swissframe.Util.StateEventEditor.Common.Test
{
    public class PressostatControl
    {
        private const string Idle = "c9ab0c3f-9a71-44dc-8fff-20fd215f3402";
        private const string Pause = "4a27b1fe-62cd-4b95-8389-d61bf803c6fd";
        private const string Emergency_Off = "cbcd3cb7-c99a-43cb-9239-510a0d7673d1";

        private readonly IRegistry _registry;
        private readonly ILogger _logger;

        private string _currentState = Idle;

        public PressostatControlStateMachineStageOne(IRegistry registry, ILogger logger)
        {
            _registry = registry;
            _logger = logger;
        }

        public void UpdateState()
        {
            var nextState = _currentState switch
            {
                Idle => IdleState(),
                Pause => PauseState(),
                Emergency_Off => Emergency_OffState(),
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
            _registry.GetInvocation("ff8c3a61-4c61-4a88-a617-bedc24a6ac7f", _logger)();

            if (event1())
            {
                _registry.GetInvocation("691c6cde-847c-4f3a-b8dd-863810b46746", _logger)();
                _registry.GetInvocation("e41b3ae0-4470-42a9-881c-4489b00acfe5", _logger)();
                _registry.GetInvocation("8ce00879-5c04-4d6b-9a50-724723d665f0", _logger)();
                _registry.GetInvocation("83d389b1-42d6-49e1-81dc-9d4c5f07195e", _logger)();
                _registry.GetInvocation("441ff1c4-028e-4cb7-9758-f7929a42db42", _logger)();
                _registry.GetInvocation("09ae7fa9-a18d-457a-ace7-bf8dbf96ccff", _logger)();

                return Pause;
            }
        }

        private string PauseState()
        {
            _registry.GetInvocation("ff8c3a61-4c61-4a88-a617-bedc24a6ac7f", _logger)();

            if (event1())
            {
                _registry.GetInvocation("83d389b1-42d6-49e1-81dc-9d4c5f07195e", _logger)();

                return Pause;
            }
            if (event2())
            {
                _registry.GetInvocation("b5646761-8167-4c73-a359-4a6f5c49a4cb", _logger)();
                _registry.GetInvocation("3a091353-9cdb-427c-a55e-363f49480a17", _logger)();

                return Idle;
            }
            if (event0())
            {
                _registry.GetInvocation("b5646761-8167-4c73-a359-4a6f5c49a4cb", _logger)();

                return Emergency_Off;
            }
        }

        private string Emergency_OffState()
        {
            _registry.GetInvocation("ff8c3a61-4c61-4a88-a617-bedc24a6ac7f", _logger)();

        }

        private bool event0()
        {
            return _registry.GetCheck("f34649b2-f8fd-4176-8c70-2d3656463e92", _logger)();
        }

        private bool event1()
        {
            return _registry.GetCheck("d07ab477-acb4-4967-a64a-1b619790c906", _logger)();
        }

        private bool event2()
        {
            return _registry.GetCheck("445e32a8-47cd-4357-90c2-ea7ef80275b4", _logger)();
        }

    }
}