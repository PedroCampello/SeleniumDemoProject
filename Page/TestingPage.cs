using OpenQA.Selenium;
using SeleniumDemo.Utility.Extensions;

namespace SeleniumDemo.Pages
{
    public class TestingPage : BasePage
    {
        By demoTestingSiteImage = By.XPath(".//*[contains(@class, 'custom-logo')]");
        public TestingPage(IWebDriver driver) : base(driver)
        {
        }
        public override TestingPage VerifyOnPage()
        {
            Driver.WaitForElementToAppear(demoTestingSiteImage);

            return this;
        }
    }
}
