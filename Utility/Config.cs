using static SeleniumDemo.Core.DriverFactory;

namespace SeleniumDemo.Utility
{
    internal class Config
    {
        public const string UrlSubDomain = "production";
        public const bool EnableScreenShots = false;
        public static BROWSER ExecutionOS = BROWSER.CHROME_HEADER;
    }
}
