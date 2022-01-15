using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geoportalLtTesting.Tests
{
    class GeoportalLoginTest : TestBase
    {
        //with correct credentials
        [TestCase("vsc_user", "vsc_test_user", TestName = "Login with correct credentials")]
        [TestCase("vsc_user", "vsc_test_", TestName = "Login with correct credentials")]
        public static void loginToPageWithCorrectCredentials(string loginNameInput, string passwordInput)
        {

            geoportalLoginPage.NavigateToDefaultPage();
            geoportalLoginPage.CheckIfUserIsLoggedIn();
            geoportalLoginPage.CLickLoginButton();
            geoportalLoginPage.EnterLoginName(loginNameInput);
            geoportalLoginPage.EnterPassword(passwordInput);
            geoportalLoginPage.ClickLoginVerifyButton();
            geoportalLoginPage.VerifyUserLogin(loginNameInput);
        }

        //with incorrect or blank credentials
        [TestCase("vsc_user", "vsc_bad", "Prisijungti nepavyko. Patikrinkite įvestą prisijungimo vardą ir slaptažodį.", TestName = "login with incorrect password")]
        [TestCase("", "", "Prisijungti nepavyko. Patikrinkite įvestą prisijungimo vardą ir slaptažodį.", TestName = "login with blank credentials")]
        public static void loginToPageWithIncorrectCredentials(string loginNameInput, string passwordInput, string expectedResult)
        {
            geoportalLoginPage.NavigateToDefaultPage();
            geoportalLoginPage.CheckIfUserIsLoggedIn();
            geoportalLoginPage.CLickLoginButton();
            geoportalLoginPage.EnterLoginName(loginNameInput);
            geoportalLoginPage.EnterPassword(passwordInput);
            geoportalLoginPage.ClickLoginVerifyButton();
            geoportalLoginPage.VerifyIncorrectCredentialsLoginErrorMessage(expectedResult);
        }
    }
}
