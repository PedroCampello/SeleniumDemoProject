using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumDemo.Core;
using SeleniumDemo.Navigators;
using SeleniumDemo.Pages;
using SeleniumDemo.Utility;

namespace SeleniumDemo.Tests
{
    public class BaseTestFixture
    {
        public static readonly string testRunFolder = GetTestRunFolderLocation();
        public static readonly string testClassFolder = GetTestClassFolderLocation();
        protected static string? TestFolder { get; set; }
        protected static IWebDriver? Driver { get; private set; }
        protected static T On<T>() where T : BasePage => Container.Resolve<T>();
        protected static T Resolve<T>() => Container.Resolve<T>();
        protected static T WithNavigator<T>() where T : INavigator => Container.Resolve<T>();

        [SetUp]
        public void StartApp()
        {
            Console.WriteLine("StartApp");
            Container.Init();
            Driver = Resolve<IWebDriver>();
            if (Driver != null)
            {
                //Do stuff, such as starting up individual external integrations or setup folders, on-demand basis
                Driver.Url = "http://demo.guru99.com/test/guru99home/";
            }
            //OnSetUp is a method that will be overriden inside individual test classes
            OnSetUp();
        }

        [TearDown] //After Test Run
        public void TearDown()
        {
            //OnTearDown is a method that will be overriden inside individual test classes
            OnTearDown();

            Container.Dispose();
            DriverFactory.KillDriver();

            Console.WriteLine("TearDown");

            if (Driver == null)
            {
                Console.WriteLine("Null driver at the end");
                return;
            }

        }
        protected virtual void OnSetUp() { }
        protected virtual void OnTearDown() { }

        public static string GetTestRunFolderLocation()
        {
            DateTime datetime = DateTime.Now;
            string strDate = datetime.ToString("yyyy-MM-dd");
            string parentFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\" + "SeleniumDemo Test Run" + "_" + strDate;
            return parentFolder;
        }

        public static string GetTestClassFolderLocation()
        {
            var classname = TestContext.CurrentContext.Test.ClassName;
            string folder = testRunFolder + "\\" + classname;
            return folder.Replace("SeleniumTest.", "");
        }
        public static string GetTestCaseFolderLocation()
        {
            DateTime datetime = DateTime.Now;
            string strDateTime = datetime.ToString("HH-mm-ss");

            var methodname = TestContext.CurrentContext.Test.MethodName;
            string folder = testClassFolder + "\\" + methodname + "_" + strDateTime;
            return folder;
        }

        public static string GetTestFolderLocation()
        {
            if (Config.EnableScreenShots == true)
            {
                if (TestFolder != null)
                {
                    return TestFolder;
                }

                DateTime datetime = DateTime.Now;
                string strDateTime = datetime.ToString("HH-mm-ss");

                var methodname = TestContext.CurrentContext.Test.MethodName;
                string folder = testClassFolder + "\\" + methodname + "_" + strDateTime;
                return folder;
            }
            return "ScreenShots_Disabled";
        }

        //Screenshot Method to be executed for assertions, as they are usually done on the test case and not by individual methods
        public void CreateScreenshot(IWebDriver driver)
        {
            if (Config.EnableScreenShots == true)
            {
                Screenshot screenshot = (Driver as ITakesScreenshot).GetScreenshot();
                //screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);

                var methodname = TestContext.CurrentContext.Test.MethodName;

                var fileName = TestFolder + "\\" + "Assertion_Complete-" + methodname + ".png";

                screenshot.SaveAsFile(fileName);
                Console.WriteLine($"Created screenshot. Saved file to location: {fileName}");
            }
        }

        //general thread wait, for use during tests
        public void SleepWait(int timer)
        {
            try
            {
                Thread.Sleep(timer);
            }
            catch (ThreadInterruptedException e)
            {
                // TODO Auto-generated catch block
                Console.WriteLine(e);
            }
        }
    }
}