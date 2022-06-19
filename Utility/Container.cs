using DryIoc;
using SeleniumDemo.Asserters;
using SeleniumDemo.Core;
using SeleniumDemo.Navigators;
using SeleniumDemo.Pages;
using SeleniumDemo.Utility.Extensions;

namespace SeleniumDemo.Utility
{
    public static class Container
    {
        private static DryIoc.Container _container = new();
        private static bool _isInitialized;

        public static void Init()
        {
            if (_container.IsDisposed)
            {
                _container = new();
            }

            RegisterDependencies();
            RegisterPageObjects();
            RegisterControls();
            RegisterNavigators();
            RegisterAsserters();

            _isInitialized = true;
        }
        public static void Dispose() => _container.Dispose();

        public static T Resolve<T>()
            => _isInitialized
                ? _container.Resolve<T>()
                : throw new ArgumentException($"You have to call {nameof(Init)}() first.");

        private static void RegisterDependencies()
        {
           // _container
                //.RegisterSingleton<DemoAPI>();

            _container.RegisterInstance(DriverFactory.GetDriver());
        }

        private static void RegisterPageObjects()
        {
            _container
                .RegisterPageObject<DemoPage>()
                .RegisterPageObject<TestingPage>();
        }

        private static void RegisterControls()
        {
            //_container.RegisterPlatformPageObject<DatePicker>;
        }

        private static void RegisterNavigators()
        {
            _container.RegisterSingleton<TestingPageNavigator>();
        }

        private static void RegisterAsserters()
        {
            _container
                .RegisterSingleton<DemoAsserter>();
        }
    }
}
