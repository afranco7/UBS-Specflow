using NUnit.Framework;
using TechTalk.SpecFlow;
using UBS_Specflow.Pages;
using UBS_Specflow.SeleniumDriver;

namespace UBS_Specflow.Steps
{
    [Binding]
    class SearchJobsSteps
    {
                 
        static HomePage homePage;
        static JobBoardPage jobBoardPage;
        static SearchJobsPage searchJobsPage;        

        [BeforeScenario]
        public static void TestInitialize() 
        {            
            homePage = new HomePage(DriverProvider.Driver);
            jobBoardPage = new JobBoardPage(DriverProvider.Driver);
            searchJobsPage = new SearchJobsPage(DriverProvider.Driver);
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
        }

        [When]
        public void WhenISelectProfessionalsLinkOnAmericas()
        {
            jobBoardPage.SelectProfessionalsLinkAmericas();           
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
            string resultMessage = searchJobsPage.searchForm.GetResultMessage(expectedResult);

            if (expectedResult)
            {
                Assert.IsFalse(resultMessage.Equals("There are no jobs that match your criteria"), "text found: " + resultMessage);
            }
            else
            {
                Assert.IsTrue(resultMessage.Equals("There are no jobs that match your criteria"),"text found: "+resultMessage);
            }
        }       

    }
}
