using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ShoppingCartTaskProject
{
    [TestClass]
    public class LoginUsers
    {
        private IWebDriver _driver;

        //here we want to create a getter, typ "prop" and click tab key
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void SetUpTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://demo.nopcommerce.com/");
        }

        [TestMethod, TestCategory("Smoke")]
       //now we want to read the data file
        //[DataSource("Microsoft.VisualStudio.TestTools.Datasource.CSV",
        //    @"H:\Proffesional Developmt\Testing\Automation\ShoppingCartTaskProject\ShoppingCartTaskProject\userLoginDetails.csv",
        //    "userLoginDetails.csv",
        //    DataAccessMethod.Sequential)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"C:\Users\admin\Documents\CERTIFICATIONS\Software Testing\Automation Class - Andre\CSharpEssentials2017\ShoppingCartTaskProject\ShoppingCartTaskProject\Files\userLoginDetails.csv",
            "userLoginDetails.csv",
            DataAccessMethod.Sequential)]
        

        public void LogUserIn()
        {
            //var username = TestContext.DataRow[0] as string;
            //var password = TestContext.DataRow[1] as string;
            //another way to write this
            var username = TestContext.DataRow["username"] as string;
            var password = TestContext.DataRow["password"] as string;

            //select login tab from the landing page
            var loginTab = _driver.FindElement(By.ClassName("ico-login"));
            loginTab.Click();

            //enter email
            var loginEmail = _driver.FindElement(By.Id("Email"));
            // loginEmail.SendKeys("kala@yahoo.com");
            loginEmail.SendKeys(username);

            //enter password
            var loginPassword = _driver.FindElement(By.Id("Password"));
            // loginPassword.SendKeys("welcome123");
            loginPassword.SendKeys(password);

            //click login button
            var loginButton = _driver.FindElement(By.ClassName("login-button"));
            loginButton.Click();
            Thread.Sleep(3000);

            //log out button
            var logoutButton = _driver.FindElement(By.ClassName("ico-logout"));

            Assert.IsTrue(logoutButton.Displayed); // this check logout
            //button is display after user has looged into account
            Thread.Sleep(2000);
        }
//-----------------------------DAY 7 ---------------------------------
        [TestMethod, TestCategory("Smoke")]
        //now we want to read the data file
        //[DataSource("Microsoft.VisualStudio.TestTools.Datasource.CSV",
        //    @"H:\Proffesional Developmt\Testing\Automation\ShoppingCartTaskProject\ShoppingCartTaskProject\userLoginDetails.csv",
        //    "userLoginDetails.csv",
        //    DataAccessMethod.Sequential)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"C:\Users\admin\Documents\CERTIFICATIONS\Software Testing\Automation Class - Andre\CSharpEssentials2017\ShoppingCartTaskProject\ShoppingCartTaskProject\DataFiles\invalidUserLoginDetails.csv",
            "invalidUserLoginDetails.csv",
            DataAccessMethod.Sequential)]
        public void InvalidUserLogin()
        {
            var usernameOrig = TestContext.DataRow["username"] as string;
            var passwordOrig = TestContext.DataRow["password"] as string;

            Debug.Assert(usernameOrig != null, "usernameOrig != null");
            var splitUsername = usernameOrig.Split('-');
            Debug.Assert(passwordOrig != null, "passwordOrig != null");
            var splitPassword = passwordOrig.Split('-');

            var username = splitUsername[1];
            var password = splitPassword[1];


            //select login tab from the landing page
            var loginTab = _driver.FindElement(By.ClassName("ico-login"));
            loginTab.Click();

            //enter email
            var loginEmail = _driver.FindElement(By.Id("Email"));
            // loginEmail.SendKeys("kala@yahoo.com");
            loginEmail.SendKeys(username);

            //enter password
            var loginPassword = _driver.FindElement(By.Id("Password"));
            // loginPassword.SendKeys("welcome123");
            loginPassword.SendKeys(password);

            //click login button
            var loginButton = _driver.FindElement(By.ClassName("login-button"));
            loginButton.Click();
            Thread.Sleep(4000);

          //  var logoutButton = _driver.FindElement(By.ClassName("ico-logout"));
            //all the test above should fial but the only way we
            //can confirm is to prove that "logout" button s not
            //displayed
          //  Assert.IsTrue(!logoutButton.Displayed);

        }


        [TestCleanup]
        public void TearDownTest()
        {
            _driver.Quit();
        }
    }
}