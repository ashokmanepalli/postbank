using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Riskcalcclassic
{
    class Program
    {
        static void Main(string[] args)
        {
            GermanFileDownload();
        }
        public static void GermanFileDownload()
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

          
            string[] fileEntries = Directory.GetFiles("C:/Csharp/File/Incoming");
            foreach(string filename in fileEntries)
            {
                //Submit Batch
                
                IWebElement Submit_button = driver.FindElement(By.XPath("//a[@href='/us/riskcalc/private/pdbatch.asp']"));
                Submit_button.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            //Selecting the Model
            IWebElement Select_model = driver.FindElement(By.XPath("//*[@id='Table2']/tbody/tr[2]/td[2]/table[2]/tbody/tr/td[2]/form/select"));
            Select_model.Click();
            Select_model.SendKeys("Germany - Extended Report" + Keys.Enter);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);

            IWebElement Choose_file = driver.FindElement(By.XPath("//*[@id='Table2']/tbody/tr[2]/td[2]/table[3]/tbody/tr[3]/td[2]/p[4]/input"));

              
             
                //Upload the file
                Choose_file.SendKeys(filename);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            //Click on Upload Button. 
            IWebElement Upload_button = driver.FindElement(By.XPath("//*[@id='upload']"));
            Upload_button.Click();
            //Click on Download Button. 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            IWebElement Start_download = driver.FindElement(By.XPath("//*[@id='SUBMIT']"));
            Start_download.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
                //}
            }
            //Log out

            IWebElement Logout_button = driver.FindElement(By.XPath("/html/body/table/tbody/tr[1]/td/table[1]/tbody/tr[1]/td[4]/a"));
            Logout_button.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            driver.Quit();



        }
    }
}
