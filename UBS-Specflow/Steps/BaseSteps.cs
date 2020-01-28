using NUnit.Framework;
using TechTalk.SpecFlow;
using UBS_Specflow.Pages;
using UBS_Specflow.SeleniumDriver;

namespace UBS_Specflow.Steps
{
    [Binding]
    class BaseSteps
    {        
        [AfterTestRun]
        public static void Cleanup()
        {
            DriverProvider.Driver.Quit();
        }
    }
}

