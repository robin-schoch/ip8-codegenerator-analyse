using System;
using Microsoft.Extensions.Logging;
using Swissframe.Util.StateEventEditor.Common.Builder;

namespace Swissframe.Util.StateEventEditor.Common.Test
{
    public class ValveControl
    {
        private const string Zuluft_heizen___Speicher_laden__A_ = "a192a063-2eb8-4ba6-b219-2c71135b376f";
        private const string Zuluft_heizen___Speicher_Bypass__B_ = "de0ed1a1-1a27-4348-af98-d6bbd184d978";
        private const string Zuluft_Bypass___Speicher_laden__C_ = "c569fc23-9b16-4c5e-ab41-2915fee6f5dc";
        private const string Zuluft_Bypass___Speicher_Bypass__D_ = "3226b317-482b-43b7-970c-2acae736ee38";
        private const string Zuluft_k_hlen___Speicher_laden__E_ = "a7e7f6e5-7f80-494c-86a6-116381c7d90f";
        private const string Zuluft_k_hlen___Speicher_Bypass__F_ = "b99f6ada-20ed-49f3-a77d-da69af1c9d1c";

        private readonly IRegistry _registry;
        private readonly ILogger _logger;

        private string _currentState = Zuluft_heizen___Speicher_laden__A_;

        public ValveControl(IRegistry registry, ILogger logger)
        {
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

            if (event0())
            {
                _registry.GetInvocation("9424d3ca-f59e-407c-8681-e553a06de20f", _logger)();

                return Zuluft_heizen___Speicher_Bypass__B_;
            }
            if (event3())
            {
                _registry.GetInvocation("2bc251da-18ff-41a5-b4e3-69e27f7e1e16", _logger)();

                return Zuluft_Bypass___Speicher_laden__C_;
            }
        return Zuluft_heizen___Speicher_laden__A_;
        }

        private string Zuluft_heizen___Speicher_Bypass__B_State()
        {

            if (event1())
            {
                _registry.GetInvocation("a32ed5f7-8063-4c49-8b27-97f61c9ed22b", _logger)();

                return Zuluft_heizen___Speicher_laden__A_;
            }
            if (event3())
            {
                _registry.GetInvocation("2bc251da-18ff-41a5-b4e3-69e27f7e1e16", _logger)();

                return Zuluft_Bypass___Speicher_Bypass__D_;
            }
        return Zuluft_heizen___Speicher_Bypass__B_;
        }

        private string Zuluft_Bypass___Speicher_laden__C_State()
        {

            if (event0())
            {
                _registry.GetInvocation("9424d3ca-f59e-407c-8681-e553a06de20f", _logger)();

                return Zuluft_Bypass___Speicher_Bypass__D_;
            }
            if (event2())
            {
                _registry.GetInvocation("674134cc-4270-4ea9-ae29-4b9590314298", _logger)();

                return Zuluft_heizen___Speicher_laden__A_;
            }
            if (event3())
            {
                _registry.GetInvocation("674134cc-4270-4ea9-ae29-4b9590314298", _logger)();

                return Zuluft_k_hlen___Speicher_laden__E_;
            }
        return Zuluft_Bypass___Speicher_laden__C_;
        }

        private string Zuluft_Bypass___Speicher_Bypass__D_State()
        {

            if (event1())
            {
                _registry.GetInvocation("a32ed5f7-8063-4c49-8b27-97f61c9ed22b", _logger)();

                return Zuluft_Bypass___Speicher_laden__C_;
            }
            if (event2())
            {
                _registry.GetInvocation("674134cc-4270-4ea9-ae29-4b9590314298", _logger)();

                return Zuluft_heizen___Speicher_Bypass__B_;
            }
            if (event3())
            {
                _registry.GetInvocation("674134cc-4270-4ea9-ae29-4b9590314298", _logger)();

                return Zuluft_k_hlen___Speicher_Bypass__F_;
            }
        return Zuluft_Bypass___Speicher_Bypass__D_;
        }

        private string Zuluft_k_hlen___Speicher_laden__E_State()
        {

            if (event0())
            {
                _registry.GetInvocation("9424d3ca-f59e-407c-8681-e553a06de20f", _logger)();

                return Zuluft_k_hlen___Speicher_Bypass__F_;
            }
            if (event2())
            {
                _registry.GetInvocation("2bc251da-18ff-41a5-b4e3-69e27f7e1e16", _logger)();

                return Zuluft_Bypass___Speicher_laden__C_;
            }
        return Zuluft_k_hlen___Speicher_laden__E_;
        }

        private string Zuluft_k_hlen___Speicher_Bypass__F_State()
        {

            if (event1())
            {
                _registry.GetInvocation("a32ed5f7-8063-4c49-8b27-97f61c9ed22b", _logger)();

                return Zuluft_k_hlen___Speicher_laden__E_;
            }
            if (event2())
            {
                _registry.GetInvocation("2bc251da-18ff-41a5-b4e3-69e27f7e1e16", _logger)();

                return Zuluft_Bypass___Speicher_Bypass__D_;
            }
        return Zuluft_k_hlen___Speicher_Bypass__F_;
        }

        private bool event0()
        {
            return _registry.GetCheck("c2518402-4b95-4eb3-9e68-18bcfb2cc0a6", _logger)();
        }

        private bool event1()
        {
            return _registry.GetCheck("e3a4abb9-376b-40ad-93d2-9cf8b39ed21e", _logger)();
        }

        private bool event2()
        {
            return _registry.GetCheck("93de9733-76f5-41ba-8b3b-13cad3c7380c", _logger)();
        }

        private bool event3()
        {
            return _registry.GetCheck("46b777d1-8791-498e-865c-6bf73c2e7da0", _logger)();
        }

    }
}