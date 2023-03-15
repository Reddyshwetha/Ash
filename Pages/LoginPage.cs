﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SPR.Pages
{
	public class LoginPage
	{
		public void LoginActions(IWebDriver driver)
		{

            driver.Manage().Window.Maximize();

            //launch the turnup portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            Thread.Sleep(1000);
            

            try

            {
                //identify the username textbox and enter valid username
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");

            }
            catch (Exception ex)

            {

                Assert.Fail("TurnUp portal home page did not launch.", ex.Message);

            }

                //identify the password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");
           

            //identify the login button;
            IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            LoginButton.Click();
            Thread.Sleep(1500);



        }
    }
}

