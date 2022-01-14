using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geoportalLtTesting.Tests
{
    class GeoportalMapTest : TestBase
    {
        [Test]
        public static void TestIfPublicServiceLayerAddsToMap()
        {
            geoportalMapPage.NavigateToDefaultPage();
            geoportalMapPage.ClickPublicServicesTab();
            geoportalMapPage.ClickPublicServicesTheme2();
            geoportalMapPage.CheckPublicServicesCheckbox();
            geoportalMapPage.ClickMapContentTab();
            geoportalMapPage.ExpandFirstLayerInMapContentTab();
            geoportalMapPage.ClickMapLayerInfoTab();
            geoportalMapPage.VerifyAddedMapLayerUrl("http://www.geoportal.lt/mapproxy/gisc_grpk/MapServer");
        }

        [Test]
        public static void TestIfPlaceNameSearchIsWorkingProperly()
        {
            geoportalMapPage.NavigateToDefaultPage();
            geoportalMapPage.InputSearchTerm();
            geoportalMapPage.PressEnterKey();
            geoportalMapPage.ClickSearchResultTab();
            geoportalMapPage.VerifySearchResultsContainText("Vilnius");
        }
    }
}
