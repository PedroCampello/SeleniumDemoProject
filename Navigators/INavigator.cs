using SeleniumDemo.Utility;

namespace SeleniumDemo.Navigators
{
    public interface INavigator
    {
        void ExecuteNavigation(NavigationParameters parameters = null);
    }
}
