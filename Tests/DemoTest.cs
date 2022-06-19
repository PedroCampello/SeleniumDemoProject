using NUnit.Framework;
using SeleniumDemo.Asserters;
using SeleniumDemo.Navigators;
using SeleniumDemo.Pages;
using SeleniumDemo.Utility;

namespace SeleniumDemo.Tests
{
    internal class DemoTest : BaseTestFixture
    {
        private static DemoAsserter DemoAsserter => Resolve<DemoAsserter>();
        protected override void OnSetUp()
        {
            Console.WriteLine("Entering Demo Test");

            if (Config.EnableScreenShots == true)
            {
                TestFolder = GetTestCaseFolderLocation();
                Directory.CreateDirectory(TestFolder);
            }
        }

        protected override void OnTearDown()
        {
            Console.WriteLine("Demo Test TearDown");
            CreateScreenshot(Driver);
        }

        [Test]
        [Category("Demo")]
        [Category("Navigation")]
        public void NavigateTesting()
        {
            var navParams = GetNavigationParameters();
            WithNavigator<TestingPageNavigator>().ExecuteNavigation(navParams);

           /* On<DemoPage>()
                .VerifyOnPage()
                //.ClickCloseButton()
                .ClickTestingButton();
          */  
            On<TestingPage>()
                .VerifyOnPage();

            DemoAsserter.AssertElementFound("demo", "demo");
        }
        private static NavigationParameters GetNavigationParameters()
        {
            var navParams = NavigationData.GetDefaultSetupParams();
            return navParams;
        }
    }
}
