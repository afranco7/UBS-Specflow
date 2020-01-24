using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBS_Specflow.BrowserActions;

namespace UBS_Specflow.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private string baseUrl;

        public HomePage(IWebDriver currentDriver)
        {
            driver = currentDriver;
            baseUrl = "https://www.ubs.com/";
        }

        private readonly By careersMenuLinkBy = By.XPath("//ul[@id='mainmenu']//a[contains(text(),'Careers')]");

        public IWebElement CareersMenuLink => driver.FindElement(careersMenuLinkBy);//Actions.FindElementBy(driver, careersMenuLinkBy);

        private readonly By SearchJobsItemLinkBy = By.XPath("//a[contains(text(),'Search jobs')]");
        public IWebElement SearchJobsItemLink => CareersMenuLink.FindElement(SearchJobsItemLinkBy);
        
        public void GoToPage()
        {
            Actions.GoToPage(driver, baseUrl);            
        }

        public void SelectSearchJobsOnCareersDropdown()
        {
            Actions.ClickOn(driver,CareersMenuLink);
            Actions.WaitForElement(driver, SearchJobsItemLinkBy, 5);
            Actions.ClickOn(driver, SearchJobsItemLink);
        }
    }
}
