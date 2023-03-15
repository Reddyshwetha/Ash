using OpenQA.Selenium;
using SPR.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SPR.Pages
{

    public class HomePage
    {

        public void GoToTMPage(IWebDriver driver)
        {

            //Navigate to Time and Material page 
            Wait.WaitToBeClicakble(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/a", 5);
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();


            Wait.WaitToBeClicakble(driver, "XPath", "/html/body/div[3]/div/div/ul[1]/li[5]/ul/li[3]/a", 5);
            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[5]/ul/li[3]/a"));
            tmOption.Click();
            Thread.Sleep(2000);



        }
    }
}

