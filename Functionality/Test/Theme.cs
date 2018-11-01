using Automation.UI.Core.CommonUtilities;
using Automation.UI.Core.DataProcessing;
using Automation.UI.Core.Selenium.PageObjects.Interpris.Platform;
using Automation.UI.Core.Selenium.PageObjects.Interpris.Product;
using Automation.UI.Core.TestAttributes;
using Automation.UI.Core.TestBase;
using Automation.UI.Functionality.TestAttributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.UI.Functionality.Test
{
    public class Theme : InterprisTestBase
    {
        //#region Test Cases
        [Test]
        [TestID(TestID.TC_ID_0011), StoryID(StoryID.SR_ID_003)]
        [Priority(PriorityLevel.Highest)]
        [TestCaseSource(typeof(DataProvider), "PrepareTestCases", new object[] { TestID.TC_ID_0011 })]
        public void TC_New_Theme(Dictionary<string, string> Data)
        {
            TestContext.Out.WriteLine("Start Test Case - {0}", TestID.TC_ID_0011);

            ThemesPage themesPage = new ThemesPage(Driver, InterprisBaseURL);
            themesPage.LogIn(Data["username"], Data["password"]);

            // Verify sign in successfully with the activated account
            //SignInTest.SignInSuccess(loginPage, headerSubPage, Data["username"], Data["password"]);

            IWebElement element = Driver.FindElement(By.LinkText("Themes"));
            element.Click();

            //Driver.FindElement(By.XPath("//div[@id='root']/div/div/div/div[2]/div[2]/div[2]/div/div/div/div/div/div/button/a/span")).Click();
            ThreadUtils.SleepMediumTime();

            Driver.FindElement(By.XPath("/ html/body/div[1]/div/div/div/div[2]/div[2]/div[2]/div/div/div/div/div/div[1]/a/button")).Click();
            ThreadUtils.SleepMediumTime();

            Driver.FindElement(By.XPath("//div[starts-with(@class,\"isoHeader\")]//span[@class=\"ant-input-group\"]/input")).SendKeys("Theme Template 2");
            ThreadUtils.SleepMediumTime();

            Driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();
            TestContext.Out.WriteLine("Theme name entered");

            ThreadUtils.SleepMediumTime();
            Assert.IsTrue(Driver.PageSource.Contains("Theme Template 2"));
            TestContext.Out.WriteLine("Verify Theme created and visible");

            //Click on the new category button
            Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div[2]/div/div/div/div/div/div/div[2]/div[1]/div/div[2]/div/div/table/tbody/tr/td[2]/button")).Click();
            
            //Enter category name in the category popup
            Driver.FindElement(By.XPath("//div[starts-with(@class,\"ant-modal-content\")]//div[@class=\"ant-modal-body\"]/input")).SendKeys("Category 1");
            
            //click on add button on the pop-up dialog
            Driver.FindElement(By.XPath("(//button[@type='button'])[9]")).Click();

            ThreadUtils.SleepMediumTime();
            //select added category to add new theme
            Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div[2]/div/div/div/div/div/div/div[2]/div[1]/div/div[2]/div/div/div/ul/li[1]/span[2]/span")).Click();

            
            //click on the + sign to add new theme in the selected category
            Driver.FindElement(By.XPath("//div[starts-with(@class,\"tree-theme\")]//i[@class=\"anticon anticon-plus\"]")).Click();

            //Enter theme name
            //Driver.FindElement(By.XPath("//div[starts-with(@class,\"ant-modal-content\")]//div[@class=\"ant-modal-body\"]/input")).SendKeys("Theme 1");
            Driver.FindElement(By.XPath("/html/body/div[8]/div/div[2]/div/div[2]/div[2]/input")).SendKeys("Theme 1");
            
            // click on add button on the pop-up dialog
            Driver.FindElement(By.XPath("(//button[@type='button'])[11]")).Click();
            ThreadUtils.SleepMediumTime();

            //click on save button
            Driver.FindElement(By.XPath("//div[@id='root']/div/div/div/div[2]/div[2]/div[2]/div/div/div/div/div/div/div/div/button")).Click();
            ThreadUtils.SleepMediumTime();
                        
            
            //click on Manage Themes
            Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div[2]/div/div/div/div/div/a[2]")).Click();
            ThreadUtils.SleepMediumTime();
            Assert.IsTrue(Driver.PageSource.Contains("Theme Template 2"));
            
            /*
            
            //updating theme template name
            Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div[2]/div/div/div/div/div/div/div[2]/div[1]/div/div[1]/table/tbody/tr/td[2]/span/span")).Click();
         
            Driver.FindElement(By.XPath("//div[starts-with(@class,\"isoHeader\")]//span[@class=\"ant-input-group\"]/input")).SendKeys("Theme updated");

            Driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();
            TestContext.Out.WriteLine("Theme name updated");

            Assert.IsTrue(Driver.PageSource.Contains("Theme updated"));
            TestContext.Out.WriteLine("Verify Theme edited and visible");
            */
            
            TestContext.Out.WriteLine("End Test Case - {0}", TestID.TC_ID_0011);
        }
                
        [Test]
        [TestID(TestID.TC_ID_0012), StoryID(StoryID.SR_ID_003)]
        [Priority(PriorityLevel.Highest)]
        [TestCaseSource(typeof(DataProvider), "PrepareTestCases", new object[] { TestID.TC_ID_0012 })]
        public void TC_Copy_BuiltinTheme(Dictionary<string, string> Data)
        {
            TestContext.Out.WriteLine("Start Test Case - {0}", TestID.TC_ID_0012);


            ThemesPage themesPage = new ThemesPage(Driver, InterprisBaseURL);
            themesPage.LogIn(Data["username"], Data["password"]);
            
            // Verify sign in successfully with the activated account
            //SignInTest.SignInSuccess(themePage, headerSubPage, Data["username"], Data["password"]);

            IWebElement element = Driver.FindElement(By.LinkText("Themes"));
            element.Click();
            ThreadUtils.SleepMediumTime();

            Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div[2]/div/div/div/div/div/div[2]/div[2]/div/section/div[1]/div/div/div/div/div/div/div/table/tbody/tr[5]/td[4]/a/span/i")).Click();
                         
            Driver.FindElement(By.XPath("//tbody[@class='ant-table-tbody']/tr[@class='ant-table-row ant-table-row-level-0']/button[@span='Employee Performance Reviews']]")).Click();

            /*
            //click on manage theme
            Driver.FindElement(By.XPath("//div[@id='root']/div/div/div/div[2]/div[2]/div[2]/div/div/div/div/div/a[2]/span")).Click();

            Assert.IsTrue(Driver.PageSource.Contains("Final Theme"));
            TestContext.Out.WriteLine("Verify Theme created and visible");

            Driver.FindElement(By.XPath("//span[@class=\"anticon anticon-edit\"]/input")).SendKeys("Theme updated");
            Driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();
            TestContext.Out.WriteLine("Theme name updated");

            Assert.IsTrue(Driver.PageSource.Contains("Theme updated"));
            TestContext.Out.WriteLine("Verify Theme edited and visible");
            */

            TestContext.Out.WriteLine("End Test Case - {0}", TestID.TC_ID_0012);
        }
    }
}

