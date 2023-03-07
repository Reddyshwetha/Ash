using System;
using OpenQA.Selenium;

namespace SPR.Pages
{
	public class HomePage
	{
		public void GoToTMPage(IWebDriver driver)
		{

            // create a new time record //

            IWebElement admistrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            admistrationDropdown.Click();

            //Navigate to the time and material //

            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();
            Thread.Sleep(1000);
        }
	}
}

