using System;
using System.Diagnostics;
using System.Reflection.Emit;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SPR.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace SPR.Pages
{
	public class TMPage
	{
		public void CreateTM(IWebDriver driver)
		{
            

            //click on create new button//

            IWebElement Createnewbutton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            Createnewbutton.Click();
            Thread.Sleep(1000);

            //select the time option from type code dropdown box//

            IWebElement typecodedropdownbutton = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            typecodedropdownbutton.Click();
            Thread.Sleep(1000);

            IWebElement Timeoption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            Timeoption.Click();

            //enter the code in code textbox//

            IWebElement CodeTextbox = driver.FindElement(By.Id("Code"));
            CodeTextbox.SendKeys("February2023");
            Thread.Sleep(1000);


            //enter the description in description textbox//

            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("Feb23");

            //enter the priceunit in priceperunit textbox//

            IWebElement priceunitTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            //IWebElement priceunitTextbox = driver.FindElement(By.Id("Price"));

            //priceunitTextbox.Click();
            //IWebElement Price = driver.FindElement(By.Id("Price"));
            priceunitTextbox.SendKeys("10");

            //click on the save button//

            IWebElement savebutton = driver.FindElement(By.Id("SaveButton"));
            savebutton.Click();
            Thread.Sleep(2000);

            //check if new time record has been created//

            IWebElement gotolastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            gotolastpagebutton.Click();
            Thread.Sleep(5000);

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

            Assert.That(newCode.Text == "February2023", "Actual code and expected code do Not match" );
            Assert.That(newDescription.Text == "Feb23","Actual description and expected description do Not match ");

           //if (newCode.Text == "February2023")
           // {
            //   Console.WriteLine("New Time record created successfully!");
           // }
           // else
           //{
            //   Console.WriteLine("New Time record unsucessfull!");
            //}
        }

        public void EditTM(IWebDriver driver)
        {

            //click on Edit Button make changes to typecode
            Thread.Sleep(1000);
            IWebElement goToLastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            goToLastpageButton.Click();

            IWebElement recordToBeEdited = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/div[2]/table/tbody/tr[2]/td[1]"));
            if (recordToBeEdited.Text == "February2023")
            {
                IWebElement LastRecordEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                LastRecordEdit.Click();
            }
            else
            {
                Assert.Fail("Record to be edited not found");
            }

            // Navigate to the last one record and click on edit
            IWebElement LastTimeRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            LastTimeRecord.Click();

            IWebElement Editbutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            Editbutton.Click();
            Thread.Sleep(2000);

            //Get Timestamp
            //var Timestamp = Stopwatch.GetTimestamp();

            // Edit new code into the code textbox
            IWebElement Editnewcode = driver.FindElement(By.Id("Code"));
            Editnewcode.Clear();
            Editnewcode.SendKeys("February2023");

            // Edit new description into the description textbox
            IWebElement Editnewdescription = driver.FindElement(By.Id("Description"));
            Editnewdescription.Clear();
            Editnewdescription.SendKeys("Feb23");

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

            Assert.That(Newcode.Text != "18", "Record hasn't been edited");


            //if (Newcode.Text == ("February2023" ))
            //{
             //   Console.WriteLine("Edited time record created sucessfully");
            //}
            //else
            //{
              //  Console.WriteLine("Time record not created sucessfully");
            //}

        }


        public void DeleteTM(IWebDriver driver)
        {

            //Navigate to last page and click on delete button

            //IWebElement Lasttimerecord = driver.FindElement(Driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            //Lasttimerecord.Click();

            IWebElement gotothelastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[last()]/a[4]/span"));
            gotothelastpagebutton.Click();
            Thread.Sleep(5000);

            IWebElement LastrecordToBeDeleted = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
           
            //lasttimerecord
            //IWebElement deletebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            //deletebutton.Click();
            //Thread.Sleep(1000);

            if (LastrecordToBeDeleted.Text == "18")
            {
                //Find and click on delete button for last reocrd
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(1000);

            }
            else
            {

                Assert.Fail("Record to be deleted not found");

            }

                // Navigate to alert option 
                driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);

            // check if the record is properly deleted
            IWebElement codedeleted = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            //Console.WriteLine(codedeleted.Text);
            Assert.That(codedeleted.Text != "18", "Record hasn't been deleted ");


            //if (codedeleted.Text == "February2023")
            //{
             //   Console.WriteLine("Time record not deleted sucessfully");
            //}
           // else
            //{
             //   Console.WriteLine("Time record deleted sucessfully");
           // }
            //driver.Quit();

           

        }
    }
}

