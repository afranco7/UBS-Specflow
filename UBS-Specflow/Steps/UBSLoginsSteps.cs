using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UBS_Specflow.Pages;

namespace UBS_Specflow.Steps
{
    [Binding]
    class UBSLoginsSteps
    {
        public static IWebDriver driver = new ChromeDriver();
        static UBSLoginsPage ubsLoginsPage;
       
        [BeforeScenario]
        public static void TestInitialize()
        {
            ubsLoginsPage = new UBSLoginsPage(driver);            
        }


        [Given(@"I have navigated to UBS Logins page")]
        public void GivenIHaveNavigatedToUBSLoginsPage()
        {
            ubsLoginsPage.GoToPage();
        }

        [When]
        public void WhenISelectUBSLoginsButton()
        {
            ubsLoginsPage.SelectUbsLoginsButton();
        }

        [When(@"I select on dropdown menu the login option (.*)")]
        public void WhenISelectOnDropdownMenuTheLoginOption(string page)
        {
            ubsLoginsPage.SelectLoginsMenuItem(page);
        }

        [Then(@"I should reach the expected (.*)")]
        public void ThenIShouldReachTheExpected(string url)
        {
            Assert.IsTrue(driver.Url.Equals(url));
        }

        [AfterFeature]
        public static void Cleanup()
        {
            driver.Quit();
        }
    }
}
