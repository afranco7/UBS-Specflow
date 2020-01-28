using NUnit.Framework;
using TechTalk.SpecFlow;
using UBS_Specflow.Pages;
using UBS_Specflow.SeleniumDriver;

namespace UBS_Specflow.Steps
{
    [Binding]
    class UBSLoginsSteps
    {
        static UBSLoginsPage ubsLoginsPage;
       
        [BeforeScenario]
        public static void TestInitialize()
        {
            ubsLoginsPage = new UBSLoginsPage(DriverProvider.Driver);            
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
            Assert.IsTrue(DriverProvider.Driver.Url.Equals(url));
        }
        
    }
}
