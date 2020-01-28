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
            public IWebElement KeywordInput => driver.FindElement(keywordInputBy);

            private readonly By locationInputBy = By.Id("sidebarSearchbox__1I0");
            public IWebElement LocationInput => driver.FindElement(locationInputBy);

            private readonly By searchButtonBy = By.Id("searchControls_BUTTON_2");
            public IWebElement SearchButton => driver.FindElement(searchButtonBy);

            private readonly By resultMessageBy = By.XPath("//h2[@role='alert']");
            public IWebElement ResultMessage => driver.FindElement(resultMessageBy);

            private readonly By firstResultLinkBy = By.XPath("//*[@id='Job_0']");
            public IWebElement FirstResultLink => driver.FindElement(firstResultLinkBy);

            public void TypeOnSearchForm(string keyword, string location)
            {
                Actions.SwitchDriverToNewTab(driver);
                JavaScriptActions.VerifyPageCompleteStateJs(driver);
                Actions.Type(KeywordInput,keyword);
                Actions.Type(LocationInput,location);
            }

            public void ClickOnSearchButton()
            {
                Actions.ClickOn(driver,SearchButton);
            }

            public string GetResultMessage(bool expectedResult)
            {              
                
                if(!expectedResult)
                {
                    Actions.WaitForElement(driver, resultMessageBy);
                    return ResultMessage.Text;
                }
                else
                {
                    Actions.WaitForElement(driver, firstResultLinkBy);
                    return FirstResultLink.Text;
                }

            }
        }

        

    }
}
