using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geoportalLtTesting.Page
{
    class GeoportalMapPage : BasePage
    {
        //puslapio adresas
        private const string PageAddress = "https://www.geoportal.lt/map/";

        //elementai
        private IWebElement _publicServicesTab => Driver.FindElement(By.Id("ui-id-5"));
        private IWebElement _publicServicesTheme2 => Driver.FindElement(By.CssSelector("#nav-panel-public-services > div > div:nth-child(2) > ul > li:nth-child(2) > span"));
        private IWebElement _publicServiceCheckbox => Driver.FindElement(By.CssSelector("#nav-panel-public-services > div > div:nth-child(2) > ul > li:nth-child(2) > ul > li:nth-child(1) > span > span.fancytree-checkbox"));
        private IWebElement _mapContentTab => Driver.FindElement(By.Id("ui-id-3"));
        private IWebElement _mapLayerExpandCollapseArrow => Driver.FindElement(By.CssSelector("#nav-panel-layer-list > div > ul:nth-child(4) > li.draggable > div.heading > i"));
        private IWebElement _mapLayerInfoTab => Driver.FindElement(By.CssSelector("#layer-tabs-3-label .fa"));
        private IWebElement _mapLayerUrl => Driver.FindElement(By.CssSelector("#nav-panel-layer-list > div > ul:nth-child(4) > li.draggable > div.content > div.tabs-content > div.layer-info > div:nth-child(1) > textarea"));
        //Map Search elements
        private IWebElement _mapSearchInput => Driver.FindElement(By.CssSelector("#ui-id-1 > span.search-wrapper > input[type=text]"));
        private IWebElement _mapSearchButton => Driver.FindElement(By.CssSelector(".fa-search"));
        private IWebElement _mapSearchTabVietovardziai => Driver.FindElement(By.CssSelector("#search-tabs > li:nth-child(1)"));
        private IReadOnlyCollection<IWebElement> _mapSearchResultTable => Driver.FindElements(By.CssSelector("#nav-panel-search-gazetteer > div.content > div > div.grid.table.jsgrid"));

        //konstruktorius su paveldėjimu
        public GeoportalMapPage(IWebDriver webdriver) : base(webdriver) { }

        //metodai:
        //nunaviguoja į testui skirtą default page
        public GeoportalMapPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public GeoportalMapPage ClickPublicServicesTab()
        {
            _publicServicesTab.Click();

            return this;
        }

        public GeoportalMapPage ClickPublicServicesTheme2()
        {
            _publicServicesTheme2.Click();

            return this;
        }

        public GeoportalMapPage CheckPublicServicesCheckbox()
        {
            _publicServiceCheckbox.Click();

            return this;
        }

        public GeoportalMapPage ClickMapContentTab()
        {
            _mapContentTab.Click();

            return this;
        }

        public GeoportalMapPage ExpandFirstLayerInMapContentTab()
        {
            _mapLayerExpandCollapseArrow.Click();

            return this;
        }

        public GeoportalMapPage ClickMapLayerInfoTab()
        {
            _mapLayerInfoTab.Click();

            return this;
        }

        public GeoportalMapPage VerifyAddedMapLayerUrl(string actualUrl)
        {
            Assert.AreEqual(actualUrl, _mapLayerUrl.Text, "New layer url does not match");

            return this;
        }

        //Map search methods:
        public GeoportalMapPage InputSearchTerm()
        {
            _mapSearchInput.SendKeys("Vilnius");

            return this;
        }

        public GeoportalMapPage PressEnterKey()
        {
            _mapSearchInput.SendKeys(Keys.Enter);

            return this;
        }

        public GeoportalMapPage ClickSearchResultTab()
        {
            _mapSearchTabVietovardziai.Click();

            return this;
        }

        public GeoportalMapPage VerifySearchResultsContainText(string text)
        {

            foreach (IWebElement row in _mapSearchResultTable)
            {
                if (row.Text.Contains(text))
                {
                    break;
                }
            }

            return this;
        }
    }
}
