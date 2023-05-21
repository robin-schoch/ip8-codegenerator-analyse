using System;
using Microsoft.Extensions.Logging;
using Swissframe.Util.StateEventEditor.Common.Builder;

namespace Swissframe.Util.StateEventEditor.Common.Test
{
    public class PressostatMonitor
    {
        private const string Idle = "0655467e-f1c0-489b-9022-aa4baf05a1f6";
        private const string Debounce = "c32eec3c-26cd-4906-8961-c49acc5d34dc";
        private const string Critical = "aa492542-d624-4b71-989f-d8a9ea866eca";
        private const string Pause = "f9eed389-e472-4061-83b4-723fe8ebdb68";
        private const string Malfunction = "8fd43cd2-1249-4a00-9e7a-5f7981b4c128";

        private readonly IRegistry _registry;
        private readonly ILogger _logger;

        private string _currentState = Idle;

        public PressostatMonitor(IRegistry registry, ILogger logger)
        {
            _registry = registry;
            _logger = logger;
        }

        public void UpdateState()
        {
            var nextState = _currentState switch
            {
                Idle => IdleState(),
                Debounce => DebounceState(),
                Critical => CriticalState(),
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
            _registry.GetInvocation("d9cda25d-30ff-4050-9e8b-9191b1e03d01", _logger)();
            _registry.GetInvocation("62ee9af9-6dcc-4a12-b665-9215a593cbb9", _logger)();

            if (event0())
            {
                _registry.GetInvocation("7a8809d6-c926-409e-bff8-f354f0d92281", _logger)();
                _registry.GetInvocation("9bc4f142-f017-4250-b78a-3df528e9c024", _logger)();
                _registry.GetInvocation("f1d7712a-6cb5-4e1f-8936-1c30f1fb4537", _logger)();
                _registry.GetInvocation("a3729f8e-a899-4c0c-b54b-5a6b35c3cab4", _logger)();

                return Debounce;
            }
        return Idle;
        }

        private string DebounceState()
        {
            _registry.GetInvocation("d9cda25d-30ff-4050-9e8b-9191b1e03d01", _logger)();
            _registry.GetInvocation("62ee9af9-6dcc-4a12-b665-9215a593cbb9", _logger)();

            if (event1())
            {
                _registry.GetInvocation("818794b5-d4cd-4261-a413-d830ed10110d", _logger)();
                _registry.GetInvocation("bc631e68-2483-4041-9797-73afd4f1a231", _logger)();
                _registry.GetInvocation("490c20da-b673-4037-9e0c-d5ed9e5008e2", _logger)();
                _registry.GetInvocation("bf30ba90-026e-40ba-a41b-f4e8a67025e4", _logger)();
                _registry.GetInvocation("54590efc-f134-42f0-a2c4-dd4bcce7146a", _logger)();

                return Pause;
            }
            if (event2())
            {
                _registry.GetInvocation("bc631e68-2483-4041-9797-73afd4f1a231", _logger)();

                return Critical;
            }
            if (event3())
            {
                _registry.GetInvocation("bc631e68-2483-4041-9797-73afd4f1a231", _logger)();
                _registry.GetInvocation("490c20da-b673-4037-9e0c-d5ed9e5008e2", _logger)();

                return Idle;
            }
        return Debounce;
        }

        private string CriticalState()
        {
            _registry.GetInvocation("d9cda25d-30ff-4050-9e8b-9191b1e03d01", _logger)();
            _registry.GetInvocation("62ee9af9-6dcc-4a12-b665-9215a593cbb9", _logger)();

            if (event0())
            {
                _registry.GetInvocation("0d8eb0ff-367e-47bd-8f5d-b2ae78075c1d", _logger)();
                _registry.GetInvocation("bc631e68-2483-4041-9797-73afd4f1a231", _logger)();
                _registry.GetInvocation("9bc4f142-f017-4250-b78a-3df528e9c024", _logger)();

                return Debounce;
            }
            if (event3())
            {
                _registry.GetInvocation("21a22292-c108-42ca-9377-76dd42fc99c3", _logger)();
                _registry.GetInvocation("490c20da-b673-4037-9e0c-d5ed9e5008e2", _logger)();
                _registry.GetInvocation("fc170a7e-9634-4c3e-a0c7-1161eef44149", _logger)();

                return Idle;
            }
        return Critical;
        }

        private string PauseState()
        {
            _registry.GetInvocation("d9cda25d-30ff-4050-9e8b-9191b1e03d01", _logger)();
            _registry.GetInvocation("62ee9af9-6dcc-4a12-b665-9215a593cbb9", _logger)();

            if (event4())
            {
                _registry.GetInvocation("bc631e68-2483-4041-9797-73afd4f1a231", _logger)();
                _registry.GetInvocation("490c20da-b673-4037-9e0c-d5ed9e5008e2", _logger)();
                _registry.GetInvocation("fc170a7e-9634-4c3e-a0c7-1161eef44149", _logger)();
                _registry.GetInvocation("a6fe5126-8570-47b1-9f07-c2377caee007", _logger)();

                return Malfunction;
            }
            if (event5())
            {
                _registry.GetInvocation("21a22292-c108-42ca-9377-76dd42fc99c3", _logger)();
                _registry.GetInvocation("490c20da-b673-4037-9e0c-d5ed9e5008e2", _logger)();
                _registry.GetInvocation("fc170a7e-9634-4c3e-a0c7-1161eef44149", _logger)();
                _registry.GetInvocation("a6fe5126-8570-47b1-9f07-c2377caee007", _logger)();

                return Idle;
            }
        return Pause;
        }

        private string MalfunctionState()
        {
            _registry.GetInvocation("d9cda25d-30ff-4050-9e8b-9191b1e03d01", _logger)();
            _registry.GetInvocation("62ee9af9-6dcc-4a12-b665-9215a593cbb9", _logger)();

        return Malfunction;
        }

        private bool event0()
        {
            return _registry.GetCheck("d07ab477-acb4-4967-a64a-1b619790c906", _logger)();
        }

        private bool event1()
        {
            return _registry.GetCheck("6f5a619e-2c8b-41f7-ab31-67ee05329f96", _logger)();
        }

        private bool event2()
        {
            return _registry.GetCheck("399acc03-b4ce-435e-be74-f3d077a642f5", _logger)();
        }

        private bool event3()
        {
            return _registry.GetCheck("231a8739-d934-446d-9e2d-3e7027677af8", _logger)();
        }

        private bool event4()
        {
            return _registry.GetCheck("a90596d8-1e5f-4412-8921-9bf8260129d2", _logger)();
        }

        private bool event5()
        {
            return _registry.GetCheck("cad5a221-9269-433b-aed5-adc90d989ef1", _logger)();
        }

    }
}