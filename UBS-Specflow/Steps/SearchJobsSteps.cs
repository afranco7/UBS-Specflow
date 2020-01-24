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
    class SearchJobsSteps
    {
        public static IWebDriver driver = new ChromeDriver();
        static HomePage homePage;
        static JobBoardPage jobBoardPage;
        static SearchJobsPage searchJobsPage;
        

        [BeforeScenario]
        public static void TestInitialize() 
        {            
            homePage = new HomePage(driver);
            jobBoardPage = new JobBoardPage(driver);
            searchJobsPage = new SearchJobsPage(driver);
        }
             

        [Given(@"I have navigated to UBS home page")]
        public void GivenIHaveNavigatedToUBSHomePage()
        {
            homePage.GoToPage();
        }

        [Given]
        public void GivenIHaveSelectedSearchJobsOnCareersDropdown()
        {
            homePage.SelectSearchJobsOnCareersDropdown();
            string url = driver.Url;
        }

        [When]
        public void WhenISelectProfessionalsLinkOnAmericas()
        {
            jobBoardPage.SelectProfessionalsLinkAmericas();
            string url = driver.Url;
        }

        [When(@"I type the search (.*) and (.*)")]
        public void WhenITypeTheSearchSoftwareAnd(string keyword, string location)
        {
            searchJobsPage.searchForm.TypeOnSearchForm(keyword, location);
        }

        [When]
        public void WhenIClickSearchButton()
        {
            searchJobsPage.searchForm.ClickOnSearchButton();
        }

        [Then(@"I should see the (.*)")]
        public void ThenIShouldSeeTheResults(bool expectedResult)
        {
            string resultMessage = searchJobsPage.searchForm.GetResultMessage();

            if (expectedResult)
            {
                Assert.AreEqual("One or more than one results found", resultMessage);
            }
            else
            {
                Assert.AreEqual("There are no jobs that match your criteria", resultMessage);
            }
        }

        [AfterFeature]
        public static void Cleanup()
        {
            driver.Quit();
        }
    }
}
