﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBS_Specflow.BrowserActions
{
    public class Actions
    {
        public static void GoToPage(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            JavaScriptActions.VerifyPageCompleteStateJs(driver);
        }

        public static void WaitForElement(IWebDriver driver, By element, int timeToWait=15)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element));
            }
            catch
            {
                throw new TimeoutException("after a " + timeToWait + " second wait, the element could not be found");
            }
           
        }

        public static void SwitchDriverToNewTab(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public static void ClickOn(IWebDriver driver, IWebElement element, int timeToWait=15)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

                element.Click();
            }
            catch
            {
                throw new TimeoutException("after a " + timeToWait + " second wait, the element could not be clicked");
            }
           
        }

        public static void Type(IWebElement element, string text, int timeToWait=15)
        {
            try
            {                
                element.SendKeys(text);
            }
            catch
            {
                throw new TimeoutException("after a " + timeToWait + " second wait, was not possible to type the text: "+text+" in the element");
            }
        }
    }
}
