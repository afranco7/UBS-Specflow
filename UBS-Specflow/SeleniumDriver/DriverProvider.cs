using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBS_Specflow.SeleniumDriver
{
    static class DriverProvider
    {
        private static IWebDriver _driver;
        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver();
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
                    _driver.Manage().Window.Maximize();
                }

                return _driver;
            }
        }

    }
}
