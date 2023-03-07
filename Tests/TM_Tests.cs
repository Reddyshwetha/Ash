using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SPR.Pages;



IWebDriver driver = new ChromeDriver(@"D:/ASH");

//login page object intialization and defination 

LoginPage loginPageObj= new LoginPage();
loginPageObj.LoginActions(driver);

//home page object intialiaztion and defination
HomePage homePageObj = new HomePage();
homePageObj.GoToTMPage(driver);

//TM page object intilazation and defination
TMPage tmpageObj = new TMPage();
tmpageObj.CreateTM(driver);

//Edit TM
tmpageObj.EditTM(driver);

//Delete TM
tmpageObj.DeleteTM(driver);


