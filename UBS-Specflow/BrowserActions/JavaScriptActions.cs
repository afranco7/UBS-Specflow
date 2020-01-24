using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBS_Specflow.BrowserActions
{
    public class JavaScriptActions
    {
        public static void VerifyPageCompleteStateJs(IWebDriver driver, double secondsToWait = 15)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch
            {
                throw new TimeoutException("after a " + secondsToWait + " second wait, the web page did not reach a complete state");
            }
        }
    }
}
