using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geoportalLtTesting.Tests
{
    class GeoportalSearchTest : TestBase
    {
        [Test]
        public static void TestIfServiceFromDataSearchAddsToMap()
        {
            geoportalSearchPage.NavigateToDefaultPage();
            geoportalSearchPage.AcceptCookies();
            geoportalSearchPage.SwitchToFrame();
            geoportalSearchPage.CheckSearchFilterServices();
            geoportalSearchPage.MoveToElement();
            geoportalSearchPage.ClickAddToMapButton();
            geoportalSearchPage.SwitchWindow();
            geoportalSearchPage.ClickMapLayerInfoTab();
            geoportalMapPage.VerifyAddedMapLayerUrl("https://www.geoportal.lt/mapproxy/nvsc_eml");
        }
    }
}
