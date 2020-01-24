using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBS_Specflow.BrowserActions;

namespace UBS_Specflow.Pages
{
    class JobBoardPage
    {
        private IWebDriver driver;
        

        public JobBoardPage(IWebDriver currentDriver)
        {
            driver = currentDriver;            
        }

        private readonly By professionalsLinkBy = By.XPath("//div[@class='teaser-body teaser__content']//span[contains(text(),'Americas')]/../..//a[contains(text(),'Professionals')]");
        public IWebElement ProfessionalsLink => driver.FindElement(professionalsLinkBy);

        public void SelectProfessionalsLinkAmericas()
        {            
            Actions.ClickOn(driver, ProfessionalsLink);            
        }
    }
}
