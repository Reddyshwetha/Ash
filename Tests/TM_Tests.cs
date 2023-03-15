using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SPR.Pages;
using SPR.Utilities;


namespace SPR.Tests
{

    [TestFixture]

    public class TM_Tests : CommonDriver
    {
        [SetUp]

        public void LoginSteps()
        {
            driver = new ChromeDriver(@"D:/ASH");
            //login page object intialization and defination
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //home page object intialiaztion and defination
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [Test]

        public void CreateTMTest()
        {
            //TM page object intilazation and defination
            TMPage tmpageObj = new TMPage();
            tmpageObj.CreateTM(driver);

        }
        [Test]

        public void EditTMTest()
        {


            //TM page object intilazation and defination
            TMPage tmpageObj = new TMPage();
            //Edit TM
            tmpageObj.EditTM(driver);

        }

       
        [Test]

        public void DeleteTMTest()
        {

            //TM page object intilazation and defination
            TMPage tmpageObj = new TMPage();
            //Delete TM
            tmpageObj.DeleteTM(driver);



        }
        [TearDown]

        public void CloseTestRun()
        {
            driver.Quit();
        }

    }

}



