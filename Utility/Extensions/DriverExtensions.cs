using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo.Utility.Extensions
{
    public static class DriverExtensions
    {
        public static void WaitAndClick(this IWebDriver driver, By by)
        {
            driver.WaitForElementToAppear(by);
            driver.Click(by);
        }
        public static void WaitForElementToAppear(this IWebDriver driver, By by)
        {
            var wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(60),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            wait.Until(d => d.FindElement(by));
        }
        public static void Click(this IWebDriver driver, By by)
        {
            driver.FindElement(by).Click();
        }
    }
}
