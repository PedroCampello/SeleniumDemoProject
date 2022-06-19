using SeleniumDemo.Pages;
using SeleniumDemo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo.Navigators
{
    public class TestingPageNavigator : INavigator
    {
        private readonly DemoPage _demoPage;

        public TestingPageNavigator(DemoPage demoPage)
        {
            _demoPage = demoPage;
        }

        public void ExecuteNavigation(NavigationParameters parameters = null)
        {
            if (parameters is not null &&
                parameters.TryGet("password", out string password) &&
                parameters.TryGet("username", out string username) &&
                parameters.TryGet("domain", out string domain))
            {
                try
                {
                    _demoPage
                        .VerifyOnPage()
                        .ClickTestingButton();
                }
                catch
                {
                }
                finally
                {
                }
            }
        }
    }
}
