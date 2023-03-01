using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V108.Animation;


//open the browser
IWebDriver driver = new ChromeDriver(@"D:/ASH");
driver.Manage().Window.Maximize();

//launch the turnup portal
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
Thread.Sleep(1000);

//identify the username textbox and enter valid username
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

//identify the password textbox and enter valid password
IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");
Thread.Sleep(1000);

//identify the login button;
IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
LoginButton.Click();

//check if user has sucessfully logged in
IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
Thread.Sleep(1000);

//check if user has sucessfully loggedin
if (helloHari.Text == "Hello hari!")
{
    Console.WriteLine("Login sucessfull!");
}
else
{
    Console.WriteLine("Login failed!");
}
//create a new time record //

IWebElement admistrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
admistrationDropdown.Click();

//Navigate to the time and material //

IWebElement timeandmaterialoption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
timeandmaterialoption.Click();

//click on create new button//

IWebElement Createnewbutton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
Createnewbutton.Click();

//select the time option from type code dropdown box//

IWebElement typecodedropdownbutton = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
typecodedropdownbutton.Click();

IWebElement Timeoption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
Timeoption.Click();

//enter the code in code textbox//

IWebElement CodeTextbox = driver.FindElement(By.Id("Code"));
CodeTextbox.SendKeys("February2023");


//enter the description in description textbox//

IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
descriptionTextbox.SendKeys("February2023");

//enter the priceunit in priceperunit textbox//

IWebElement priceunitTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
//IWebElement priceunitTextbox = driver.FindElement(By.Id("Price"));

//priceunitTextbox.Click();
//IWebElement Price = driver.FindElement(By.Id("Price"));
priceunitTextbox.SendKeys("10");  

//click on the save button//

IWebElement savebutton = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
savebutton.Click();

//click on the gotolastpage button//

IWebElement gotolastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
gotolastpagebutton.Click();
Thread.Sleep(3000);   

IWebElement newcode = driver.FindElement(By.Id("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[7]/td[1]"));

if (newcode.Text == "February2023!")
{
    Console.WriteLine("New Time record created successfully!");
}
else
{
    Console.WriteLine("New Time record unsucessfull!");
}

// Navigate to the last one record and click on edit
IWebElement lasttimerecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
lasttimerecord.Click();

IWebElement Editbutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
Editbutton.Click();
Thread.Sleep(2000);

//Get Timestamp
var Timestamp = Stopwatch.GetTimestamp();

// Edit new code into the code textbox
IWebElement Editnewcode = driver.FindElement(By.Id("Code"));
Editnewcode.Clear();
Editnewcode.SendKeys("February2023" + Timestamp);

// Edit new description into the description textbox
IWebElement Editnewdescription = driver.FindElement(By.Id("Description"));
Editnewdescription.Clear();
Editnewdescription.SendKeys("February2023 Description");

// Edit new price per unit into the price per unit text box
IWebElement EditPriceperunittextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
EditPriceperunittextbox.Click();

IWebElement newprice = driver.FindElement(By.Id("Price"));
newprice.Clear();
EditPriceperunittextbox.Click();
newprice.SendKeys("18");

// Click on save button
IWebElement SaveButton = driver.FindElement(By.Id("SaveButton"));
SaveButton.Click();
Thread.Sleep(1000);

//Check if new time record has created
IWebElement gotothelastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[last()]/a[4]/span"));
gotothelastpagebutton.Click();
Thread.Sleep(3000);

IWebElement Newcode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

if (Newcode.Text == ("February2023" + Timestamp))
{
    Console.WriteLine("Edited time record created sucessfully");
}
else
{
    Console.WriteLine("Time record not created sucessfully");
}

// Navigate to last page and click on delete button
IWebElement Lasttimerecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
Lasttimerecord.Click();

IWebElement deletebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
deletebutton.Click();
Thread.Sleep(1000);

// Navigate to alert option 
driver.SwitchTo().Alert().Accept();
Thread.Sleep(5000);

// check if the record is properly deleted
IWebElement codedeleted = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
//Console.WriteLine(codedeleted.Text);

if (codedeleted.Text == "\"February2023\"+Timestamp")
{
    Console.WriteLine("Time record not deleted sucessfully");
}
else
{
    Console.WriteLine("Time record deleted sucessfully");
}
driver.Quit();


