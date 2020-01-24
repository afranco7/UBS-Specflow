using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBS_Specflow.BrowserActions;

namespace UBS_Specflow.Pages
{
    public class SearchJobsPage
    {
        private IWebDriver driver;
        public SearchForm searchForm;
        
        public SearchJobsPage(IWebDriver currentDriver)
        {            
            driver = currentDriver;            
            searchForm = new SearchForm(this);            
        }

        public class SearchForm
        {
            private IWebDriver driver;            

            public SearchForm(SearchJobsPage searchJobsPage)
            {               
                driver = searchJobsPage.driver; 
            }

            private readonly By keywordInputBy = By.Id("sidebarSearchbox__1HZ");
            public IWebElement keywordInput => driver.FindElement(keywordInputBy);

            private readonly By locationInputBy = By.Id("sidebarSearchbox__1I0");
            public IWebElement locationInput => driver.FindElement(locationInputBy);

            private readonly By searchButtonBy = By.Id("searchControls_BUTTON_2");
            public IWebElement searchButton => driver.FindElement(searchButtonBy);

            private readonly By resultMessageBy = By.XPath("//h2[@role='alert']");
            public IWebElement resultMessage => driver.FindElement(resultMessageBy);

            public void TypeOnSearchForm(string keyword, string location)
            {
                Actions.SwitchDriverToNewTab(driver);
                JavaScriptActions.VerifyPageCompleteStateJs(driver);
                Actions.Type(keywordInput,keyword);
                Actions.Type(locationInput,location);
            }

            public void ClickOnSearchButton()
            {
                Actions.ClickOn(driver,searchButton);
            }

            public string GetResultMessage()
            {              
                
                try
                {
                    Actions.WaitForElement(driver, resultMessageBy);
                    return resultMessage.Text;
                }
                catch
                {
                    return "One or more than one results found";
                }

            }
        }

        

    }
}
