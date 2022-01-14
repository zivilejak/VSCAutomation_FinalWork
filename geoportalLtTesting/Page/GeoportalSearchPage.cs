using NUnit.Framework;
using OpenQA.Selenium;
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

        public GeoportalSearchPage CheckSearchFilterServices()
        {
            _servicesCheckbox.Click();

            return this;
        }

        public GeoportalSearchPage ClickAddToMapButton()
        {
            _searchResultAddToMapButton.Click();

            return this;
        }
    }
}
