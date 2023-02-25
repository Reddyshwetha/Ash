using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//open the browser
IWebDriver driver = new ChromeDriver();

//launch the turnup portal
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

//identify the username textbox and enter valid username
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

//identify the password textbox and enter valid password
IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

//identify the login button;
IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
LoginButton.Click();

//check if user has sucessfully logged in
IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

//check if user has sucessfully loggedin
if (helloHari.Text == "Hello hari!")
{
    Console.WriteLine("Login sucessfull!");
}
else
{
    Console.WriteLine("Login failed!");
}

