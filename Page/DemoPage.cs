using OpenQA.Selenium;
using SeleniumDemo.Utility.Extensions;

namespace SeleniumDemo.Pages
{
    public class DemoPage : BasePage
    { 
        By demoSiteImage = By.XPath(".//*[.='Demo Site']");
        By testingButton = By.XPath(".//a[@href='http://www.guru99.com/software-testing.html']");
        By closeButton = By.XPath(".//*[.='Close ad']");
        public DemoPage(IWebDriver driver) : base(driver)
        {
        }
        public override DemoPage VerifyOnPage()
        {
            Driver.WaitForElementToAppear(demoSiteImage);

            return this;
        }
        public DemoPage ClickCloseButton()
        {
            Driver.Click(closeButton);
            CreateScreenshotPage();

            return this;
        }
        public DemoPage ClickTestingButton()
        {
            Driver.Click(testingButton);
            CreateScreenshotPage();

            return this;
        }
    }
}
