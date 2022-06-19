using static SeleniumDemo.Core.DriverFactory;

namespace SeleniumDemo.Utility.Extensions
{
    public static class EnumExtensions
    {
        public static bool IsChrome(this BROWSER os)
            => os == BROWSER.CHROME_HEADER || os == BROWSER.CHROME_NOHEADER;
    }
}
