using System;
using Microsoft.Extensions.Logging;
using Swissframe.Util.StateEventEditor.Common.Builder;

namespace Swissframe.Util.StateEventEditor.Common.Test
{
    public class HeatPumpControl
    {
        private const string Idle = "f4911508-4d10-4346-afca-7c95ef8a18e6";
        private const string Normal = "b3cbc28c-13a9-4d0f-972a-42eae5ebb9f2";
        private const string Critical_1 = "6717184f-301b-4d04-8c68-0d18fe51eb9e";
        private const string Critical_2 = "5fdd3952-ca24-4aa7-bdc3-e36fd5a45d15";
        private const string Critical_3 = "828806e8-142f-4914-9e93-7eb3615c0c18";
        private const string Defrost = "d84a245f-aef0-412c-8281-e7be48047a51";
        private const string Drip_off = "2fa51d75-28b6-465b-ada8-6a37b212ae6e";
        private const string Pause = "18062b3b-1140-40c2-bab0-d3a1bcb07d9e";
        private const string Malfunction = "d196619c-336c-42ca-a15e-c916b8e949b6";

        private readonly IRegistry _registry;
        private readonly ILogger _logger;

        private string _currentState = Idle;

        public HeatPumpControl(IRegistry registry, ILogger logger)
        {
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
            _registry.GetInvocation("05d527d8-da60-4790-a9f2-714e4e5f0f10", _logger)();
            _registry.GetInvocation("1cfafc09-5d4d-49fe-a87e-d47be164b2f5", _logger)();

            if (event0())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Malfunction;
            }
            if (event1())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9fdcf8fa-4e7c-4f82-a37d-a554bb66ceb3", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Pause;
            }
            if (event3())
            {
                _registry.GetInvocation("264930c2-b386-4ae2-a9c7-b59a4290cb3e", _logger)();

                return Normal;
            }
            if (event5())
            {
                _registry.GetInvocation("264930c2-b386-4ae2-a9c7-b59a4290cb3e", _logger)();

                return Critical_1;
            }
        return Idle;
        }

        private string NormalState()
        {
            _registry.GetInvocation("05d527d8-da60-4790-a9f2-714e4e5f0f10", _logger)();
            _registry.GetInvocation("cb9339ac-86ab-4509-b251-35effaf1e358", _logger)();

            if (event0())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Malfunction;
            }
            if (event1())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9fdcf8fa-4e7c-4f82-a37d-a554bb66ceb3", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Pause;
            }
            if (event2())
            {
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Idle;
            }
            if (event6())
            {
                _registry.GetInvocation("3d85aa8a-d12d-4269-8faf-ebaa18f2bd3e", _logger)();

                return Critical_1;
            }
        return Normal;
        }

        private string Critical_1State()
        {
            _registry.GetInvocation("05d527d8-da60-4790-a9f2-714e4e5f0f10", _logger)();
            _registry.GetInvocation("cb9339ac-86ab-4509-b251-35effaf1e358", _logger)();

            if (event0())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Malfunction;
            }
            if (event1())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9fdcf8fa-4e7c-4f82-a37d-a554bb66ceb3", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Pause;
            }
            if (event2())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Idle;
            }
            if (event4())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("9fdcf8fa-4e7c-4f82-a37d-a554bb66ceb3", _logger)();

                return Normal;
            }
            if (event7())
            {
                _registry.GetInvocation("89a7a2ad-9c15-464e-804c-9c04617351e8", _logger)();
                _registry.GetInvocation("b803a268-cdea-4a08-8ed9-328ee750f409", _logger)();

                return Critical_2;
            }
            if (event9())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("7459f3c3-4f0c-462b-b775-388db66ce52f", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();
                _registry.GetInvocation("5651ce68-94f9-46c4-89ca-3da52b71b3e3", _logger)();

                return Defrost;
            }
        return Critical_1;
        }

        private string Critical_2State()
        {
            _registry.GetInvocation("05d527d8-da60-4790-a9f2-714e4e5f0f10", _logger)();
            _registry.GetInvocation("cb9339ac-86ab-4509-b251-35effaf1e358", _logger)();

            if (event0())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Malfunction;
            }
            if (event1())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9fdcf8fa-4e7c-4f82-a37d-a554bb66ceb3", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Pause;
            }
            if (event2())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Idle;
            }
            if (event4())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("9fdcf8fa-4e7c-4f82-a37d-a554bb66ceb3", _logger)();

                return Normal;
            }
            if (event10())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("7459f3c3-4f0c-462b-b775-388db66ce52f", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();
                _registry.GetInvocation("5651ce68-94f9-46c4-89ca-3da52b71b3e3", _logger)();

                return Defrost;
            }
            if (event11())
            {
                _registry.GetInvocation("b09a8339-e8a6-4b71-8930-a6e2607af2fe", _logger)();

                return Critical_3;
            }
        return Critical_2;
        }

        private string Critical_3State()
        {
            _registry.GetInvocation("05d527d8-da60-4790-a9f2-714e4e5f0f10", _logger)();
            _registry.GetInvocation("cb9339ac-86ab-4509-b251-35effaf1e358", _logger)();

            if (event0())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Malfunction;
            }
            if (event1())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9fdcf8fa-4e7c-4f82-a37d-a554bb66ceb3", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Pause;
            }
            if (event2())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();

                return Idle;
            }
            if (event10())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("7459f3c3-4f0c-462b-b775-388db66ce52f", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();
                _registry.GetInvocation("5651ce68-94f9-46c4-89ca-3da52b71b3e3", _logger)();

                return Defrost;
            }
            if (event8())
            {
                _registry.GetInvocation("b803a268-cdea-4a08-8ed9-328ee750f409", _logger)();

                return Critical_2;
            }
        return Critical_3;
        }

        private string DefrostState()
        {
            _registry.GetInvocation("05d527d8-da60-4790-a9f2-714e4e5f0f10", _logger)();
            _registry.GetInvocation("1cfafc09-5d4d-49fe-a87e-d47be164b2f5", _logger)();

            if (event0())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Malfunction;
            }
            if (event1())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9fdcf8fa-4e7c-4f82-a37d-a554bb66ceb3", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Pause;
            }
            if (event14())
            {
                _registry.GetInvocation("607de69d-7219-4ff6-a04b-c746470916f0", _logger)();

                return Drip_off;
            }
        return Defrost;
        }

        private string Drip_offState()
        {
            _registry.GetInvocation("05d527d8-da60-4790-a9f2-714e4e5f0f10", _logger)();
            _registry.GetInvocation("1cfafc09-5d4d-49fe-a87e-d47be164b2f5", _logger)();

            if (event0())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Malfunction;
            }
            if (event1())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9fdcf8fa-4e7c-4f82-a37d-a554bb66ceb3", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Pause;
            }
            if (event12())
            {
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9fdcf8fa-4e7c-4f82-a37d-a554bb66ceb3", _logger)();
                _registry.GetInvocation("264930c2-b386-4ae2-a9c7-b59a4290cb3e", _logger)();

                return Normal;
            }
        return Drip_off;
        }

        private string PauseState()
        {
            _registry.GetInvocation("05d527d8-da60-4790-a9f2-714e4e5f0f10", _logger)();
            _registry.GetInvocation("1cfafc09-5d4d-49fe-a87e-d47be164b2f5", _logger)();

            if (event0())
            {
                _registry.GetInvocation("fcfa1c2c-071d-43db-916f-e6637e526da9", _logger)();
                _registry.GetInvocation("dfd99d34-76a2-4824-b24a-02076f19b623", _logger)();
                _registry.GetInvocation("27b7e9f3-552c-47c8-869d-88943731e29a", _logger)();
                _registry.GetInvocation("9c1d2afd-1021-4e7a-ba12-8bcfce142ec0", _logger)();

                return Malfunction;
            }
            if (event13())
            {
                _registry.GetInvocation("264930c2-b386-4ae2-a9c7-b59a4290cb3e", _logger)();

                return Normal;
            }
        return Pause;
        }

        private string MalfunctionState()
        {
            _registry.GetInvocation("05d527d8-da60-4790-a9f2-714e4e5f0f10", _logger)();
            _registry.GetInvocation("1cfafc09-5d4d-49fe-a87e-d47be164b2f5", _logger)();

        return Malfunction;
        }

        private bool event0()
        {
            return _registry.GetCheck("9cb42634-5f7a-48d6-803a-d5ab2733d44c", _logger)();
        }

        private bool event1()
        {
            return _registry.GetCheck("c87fb69c-0c96-40e0-827d-203832f73d8b", _logger)();
        }

        private bool event2()
        {
            return _registry.GetCheck("ebad418a-d2c7-40f4-a4ef-5a7e0df472ae", _logger)();
        }

        private bool event3()
        {
            return _registry.GetCheck("ad0a2ca2-8edb-4712-b9ee-48e9df88140a", _logger)();
        }

        private bool event4()
        {
            return _registry.GetCheck("96c1b687-a348-4c5f-b63b-4c20f3eb2377", _logger)();
        }

        private bool event5()
        {
            return _registry.GetCheck("1e3325ef-6bb0-4206-abb3-bdc7dbbd3950", _logger)();
        }

        private bool event6()
        {
            return _registry.GetCheck("fed23890-1d6f-4fa1-8b30-8a2985770bc7", _logger)();
        }

        private bool event7()
        {
            return _registry.GetCheck("aca6610e-dc60-467d-b612-3a31f224b981", _logger)();
        }

        private bool event8()
        {
            return _registry.GetCheck("5570deb1-6b3b-42bd-a912-404fe66de337", _logger)();
        }

        private bool event9()
        {
            return _registry.GetCheck("f3332ef1-e8e0-45e8-8ef3-a827eb3d64f5", _logger)();
        }

        private bool event10()
        {
            return _registry.GetCheck("231ed4f2-2a59-4603-acdc-de391663b1c0", _logger)();
        }

        private bool event11()
        {
            return _registry.GetCheck("9fe1a668-dfb7-4ec2-b1ff-4ac309afebec", _logger)();
        }

        private bool event12()
        {
            return _registry.GetCheck("70d3b78e-78f0-4450-89d5-4d3ddeaf6962", _logger)();
        }

        private bool event13()
        {
            return _registry.GetCheck("a7d3c633-42f5-40f7-90ce-f59fd359d41f", _logger)();
        }

        private bool event14()
        {
            return _registry.GetCheck("0c1888dd-868a-45c0-b159-95eea4edd260", _logger)();
        }

    }
}