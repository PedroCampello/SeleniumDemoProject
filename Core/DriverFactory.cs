using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumDemo.Utility;
using SeleniumDemo.Utility.Extensions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumDemo.Core
{
    public class DriverFactory
    {
        private static IWebDriver? _webDriver;

        public static BROWSER ExecutionOS = Config.ExecutionOS;
        public static bool IsChrome => ExecutionOS.IsChrome();

        public enum BROWSER
        {
            CHROME_HEADER,
            CHROME_NOHEADER,
        }

        public static IWebDriver GetDriver()
        {
            if (_webDriver == null)
            {
                _webDriver = ExecutionOS switch
                {
                    BROWSER.CHROME_HEADER => GetChromeDriver(),
                    BROWSER.CHROME_NOHEADER => GetChromeDriverHeaderless(),
                    _ => throw new NotImplementedException($"Driver for {ExecutionOS} has not been implemented."),
                };
            }

            return _webDriver;
        }

        static public IWebDriver GetChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _webDriver.Manage().Window.Maximize();

            Console.WriteLine("end of create Chrome driver");
            return _webDriver;
        }
        static public IWebDriver GetChromeDriverHeaderless()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver(chromeOptions);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            Console.WriteLine("end of create Headerless Chrome driver");
            return _webDriver;
        }
        public static void KillDriver()
        {
            Console.WriteLine("start of killdriver");
            _webDriver.Quit();
            _webDriver = null;
            Console.WriteLine("end of killdriver");
        }
    }
}

