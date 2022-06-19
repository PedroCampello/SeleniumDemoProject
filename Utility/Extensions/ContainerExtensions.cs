using DryIoc;
using SeleniumDemo.Pages;

namespace SeleniumDemo.Utility.Extensions
{
    public static class ContainerExtensions
    {
        public static DryIoc.Container RegisterPageObject<T>(this DryIoc.Container container) where T : BasePage
        {
            container.Register<T>(Reuse.Singleton);

            return container;
        }

        public static DryIoc.Container RegisterSingleton<T>(this DryIoc.Container container)
        {
            container.Register<T>(Reuse.Singleton);

            return container;
        }
    }
}
