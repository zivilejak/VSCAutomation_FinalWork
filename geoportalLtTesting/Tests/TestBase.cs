using geoportalLtTesting.Drivers;
using geoportalLtTesting.Page;
using geoportalLtTesting.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geoportalLtTesting.Tests
{
    class TestBase
    {
        protected static IWebDriver Driver;

        //public - kad testai galetu naudoti
        public static GeoportalLoginPage geoportalLoginPage;
        public static GeoportalMapPage geoportalMapPage;
        public static GeoportalSearchPage geoportalSearchPage;

        [OneTimeSetUp] //visus testus pakels ant vieno browserio - ivykdys visus testus
        public static void SetUp()
        {
            Driver = CustomDriver.GetChromeDriver();

            //inicializuoti objekta
            geoportalLoginPage = new GeoportalLoginPage(Driver);
            geoportalMapPage = new GeoportalMapPage(Driver);
            geoportalSearchPage = new GeoportalSearchPage(Driver);
        }

        [OneTimeTearDown] //kas uzcloseintu browseri po visu testu
        public static void TearDown()
        {
            Driver.Quit();
        }

        [TearDown]
        public static void TakeScreeshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                //metodo kur padaro screenshota
                MyScreenshot.TakeScreenshot(Driver);
            }
        }
    }
}
