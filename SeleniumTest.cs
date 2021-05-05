using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject_New
{
    [TestClass]
    public class SeleniumTest
    {
        [TestMethod]
        public void GermanFileDownload()
        {
            //Launch Browser
           
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", @"C:\Csharp\File\Outgoing");

            IWebDriver driver = new ChromeDriver(chromeOptions);
            driver.Url = "https://classic.riskcalc.moodysanalytics.com/";
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            //Login
            IWebElement userName_Textbox = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[4] / td / table / tbody / tr[1] / td / table / tbody / tr[4] / td / input"));
            IWebElement password_Textbox = driver.FindElement(By.XPath("/html/body/table/tbody/tr[4]/td/table/tbody/tr[1]/td/table/tbody/tr[6]/td/input"));
            IWebElement Login_button = driver.FindElement(By.XPath("//*[@id='go']"));
            userName_Textbox.Click();
            userName_Textbox.SendKeys("rcqa31");
            password_Textbox.SendKeys("qaqaqa");
            Login_button.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            //Submit Batch
            IWebElement Submit_button = driver.FindElement(By.XPath("/html/body/table/tbody/tr[2]/td/table/tbody/tr[2]/td/table/tbody/tr/td[7]/a"));
            Submit_button.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            //Selecting the Model
            IWebElement Select_model = driver.FindElement(By.XPath("//*[@id='Table2']/tbody/tr[2]/td[2]/table[2]/tbody/tr/td[2]/form/select"));
            Select_model.Click();
            Select_model.SendKeys("Germany - Extended Report" + Keys.Enter);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);

            IWebElement Choose_file = driver.FindElement(By.XPath("//*[@id='Table2']/tbody/tr[2]/td[2]/table[3]/tbody/tr[3]/td[2]/p[4]/input"));
         


            //Upload the file
            Choose_file.SendKeys("C:/Csharp/File/Incoming/Germany Extended RC Classic Tele Columbus AG.csv");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            //Click on Upload Button. 
            IWebElement Upload_button = driver.FindElement(By.XPath("//*[@id='upload']"));
            Upload_button.Click();
            //Click on Download Button. 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            IWebElement Start_download = driver.FindElement(By.XPath("//*[@id='SUBMIT']"));
            Start_download.Click();
            
            //Log out
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            IWebElement Logout_button = driver.FindElement(By.XPath("/html/body/table/tbody/tr[1]/td/table[1]/tbody/tr[1]/td[4]/a"));
            Logout_button.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            driver.Quit();

          

        }
    }
}
