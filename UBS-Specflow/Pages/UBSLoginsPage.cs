using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBS_Specflow.BrowserActions;

namespace UBS_Specflow.Pages
{
    class UBSLoginsPage
    {
        private IWebDriver driver;
        private string baseUrl;

        public UBSLoginsPage(IWebDriver currentDriver)
        {
            driver = currentDriver;
            baseUrl = "https://www.ubs.com/global/en/logins.html";
        }

        private readonly By ubsLoginsButtonBy = By.Id("menulabel-8001");
        public IWebElement UBSLoginsButton => driver.FindElement(ubsLoginsButtonBy);

        private readonly By UBSSafeMenuItemBy = By.Id("menulabel-8327");
        public IWebElement UBSSafMenuItem => driver.FindElement(UBSSafeMenuItemBy);

        private readonly By UBSConnectMenuItemBy = By.Id("menulabel-83112");
        public IWebElement UBSConnectMenuItem => driver.FindElement(UBSConnectMenuItemBy);

        public void GoToPage()
        {
            Actions.GoToPage(driver, baseUrl);
        }

        public void SelectUbsLoginsButton()
        {
            Actions.ClickOn(driver, UBSLoginsButton);            
        }

        public void SelectLoginsMenuItem(string page)
        {
            if (page.Equals("UBS Safe"))
            {
                Actions.ClickOn(driver, UBSSafMenuItem);
            }
            else if (page.Equals("UBS Connect"))
            {
                Actions.ClickOn(driver, UBSConnectMenuItem);
                JavaScriptActions.VerifyPageCompleteStateJs(driver);
            }
            
        }
    }
}
