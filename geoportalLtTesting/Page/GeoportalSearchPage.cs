using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geoportalLtTesting.Page
{
    class GeoportalSearchPage : BasePage
    {
        //puslapio adresas
        private const string PageAddress = "https://www.geoportal.lt/geoportal/paieska";

        //elementai
        private IWebElement _servicesCheckbox => Driver.FindElement(By.CssSelector("#checkboxfield-1025"));
        private IWebElement _searchResultAddToMapButton => Driver.FindElement(By.CssSelector("#dataview-1078 > div:nth-child(1) > div > div > div.results-item-data > div > div.document-item.profile-nmdp-iso-19119 > div.md-results-actions > a:nth-child(1)"));
        private IWebElement _mapLayerInfoTab => Driver.FindElement(By.CssSelector("#layer-tabs-2-label"));

        private IWebElement _popup => Driver.FindElement(By.CssSelector("body > div.cc-window.cc-banner.cc-type-info.cc-theme-spaced.cc-bottom.cc-color-override--1762072787 > div > a"));

        //konstruktorius su paveldėjimu
        public GeoportalSearchPage(IWebDriver webdriver) : base(webdriver) { }

        //metodai:
        //nunaviguoja į testui skirtą default page
        public GeoportalSearchPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public GeoportalSearchPage SwitchToFrame()
        {
            Driver.SwitchTo().Frame(0);

            return this;
        }

        public GeoportalSearchPage CheckSearchFilterServices()
        {
            _servicesCheckbox.Click();

            return this;
        }

        public GeoportalSearchPage MoveToElement()
        {
            Actions action = new Actions(Driver);

            action.MoveToElement(_searchResultAddToMapButton);

            return this;
        }
        public GeoportalSearchPage AcceptCookies()
        {
            Cookie myCookie = new Cookie("__utma",
                "9865123.462022413.1642257983.1642257983.1642257983.1",
                ".geoportal.lt",
                "/",
                DateTime.Now.AddDays(5));

            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();

            return this;
        }

        public GeoportalSearchPage ClickAddToMapButton() //uzdaryti popup
        {
            _searchResultAddToMapButton.Click();

            return this;
        }
        public GeoportalSearchPage SwitchWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());

            return this;
        }

        public GeoportalSearchPage ClickMapLayerInfoTab()
        {
            _mapLayerInfoTab.Click();

            return this;
        }
    }
}
