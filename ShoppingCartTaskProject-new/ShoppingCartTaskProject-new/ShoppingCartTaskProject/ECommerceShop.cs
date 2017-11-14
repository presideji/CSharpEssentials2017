using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ShoppingCartTaskProject.Pages;

namespace ShoppingCartTaskProject
{
    [TestClass]
    public class ECommerceShop
    {
        private IWebDriver _driver;

        //here we eant to creat a getter, typ "prop" and click tab key
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void SetUpTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://demo.nopcommerce.com/");
        }

        [TestMethod, TestCategory("SIT")]
        public void CreateANewAccount()
        {
            var createAccount = new CreatAccount();
            createAccount.RegisterAccount();

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

            //as we did for CreateANewAccount() we will do
            //var for loginPage in "LoginPage.cs"

            var loginPage = new LoginPage(_driver);
            loginPage.LoginAsValidUser(username, password);

            var logoutButton = _driver.FindElement(By.ClassName("ico-logout"));
            Assert.IsTrue(logoutButton.Displayed);

        }
//---------------------------------------------------
        ////some code above this line were cut and put in "LoginPage.cs
        ////log out button

        //  logoutButton = _driver.FindElement(By.ClassName("ico-logout"));

        //    Assert.IsTrue(logoutButton.Displayed); // this check logout
        //    //button is display after user has looged into account
        //    Thread.Sleep(2000);
        //}


        //[TestMethod, TestCategory("Smoke")]
        ////now we want to read the data file
        ////[DataSource("Microsoft.VisualStudio.TestTools.Datasource.CSV",
        ////    @"H:\Proffesional Developmt\Testing\Automation\ShoppingCartTaskProject\ShoppingCartTaskProject\userLoginDetails.csv",
        ////    "userLoginDetails.csv",
        ////    DataAccessMethod.Sequential)]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
        //        @"C:\Users\admin\Documents\CERTIFICATIONS\Software Testing\Automation Class - Andre\CSharpEssentials2017\ShoppingCartTaskProject\ShoppingCartTaskProject\DataFiles\invalidUserLoginDetails.csv",
        //        "invalidUserLoginDetails.csv",
        //        DataAccessMethod.Sequential)]
        //public void InvalidUserLogin()
        //{
        //    //    var usernameOrig = TestContext.DataRow["username"] as string;
        //    //    var passwordOrig = TestContext.DataRow["password"] as string;


        //    //select login tab from the landing page
        //    var loginTab = _driver.FindElement(By.ClassName("ico-login"));
        //    loginTab.Click();

        //    //enter email
        //    if (username != null)
        //    {
        //        var loginEmail = _driver.FindElement(By.Id("Email"));
        //        loginEmail.SendKeys(username);
        //    }

        //    // enter password
        //    if (password != null)

        //    {
        //        var loginPassword = _driver.FindElement(By.Id("Password"));
        //        loginPassword.SendKeys(password);
        //    }

        //    //click login button
        //    var loginButton = _driver.FindElement(By.ClassName("login-button"));
        //    loginButton.Click();

        //    Thread.Sleep(4000);

        //     }

        //      [TestCleanup]
        //        public void TearDownTest()
        //        {
        //            _driver.Quit();

        //         }

    }


  }

