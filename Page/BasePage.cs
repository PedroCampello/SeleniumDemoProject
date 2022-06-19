using OpenQA.Selenium;
using SeleniumDemo.Tests;
using SeleniumDemo.Utility;
using System.Diagnostics;

namespace SeleniumDemo.Pages
{
    public abstract class BasePage
	{
		private static int count = 1;
		protected IWebDriver Driver { get; init; }
		//protected AppiumDriver<AppiumWebElement> AppiumDriver => (AppiumDriver<AppiumWebElement>)Driver;

		public BasePage(IWebDriver driver)
		{
			Driver = driver;
		}

		public virtual BasePage VerifyOnPage() => this;

		protected By GetBy(string element) => By.XPath($"//*[@text = '{element}']");

		//Screenshot Method to be executed by individual methods
		public void CreateScreenshotPage()
		{
			if (Config.EnableScreenShots == true)
			{
				Screenshot screenshot = (Driver as ITakesScreenshot).GetScreenshot();
				//screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);
				string stepcount = count.ToString();
				count++;
				var methodname = new StackTrace()?.GetFrame(1)?.GetMethod()?.Name;
				string testFolder = BaseTestFixture.GetTestFolderLocation();
				var fileName = testFolder + "\\" + stepcount + "_" + methodname + ".png";
				screenshot.SaveAsFile(fileName);
				//Console.WriteLine($"Created screenshot. Saved file to location: {fileName}");
			}
		}

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

