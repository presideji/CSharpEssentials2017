using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ShoppingCartTaskProject.Pages;
using ShoppingCartTaskProject.Utilities;

namespace ShoppingCartTaskProject
//NOTE THIS IS WHERE WE CALL ALL TH EVARIOUS CLASSES WE CREATED
// IN OTHER TO MAKE OUR PROGRAM LOOK NEAT
{
    [TestClass]
    public class ECommerceShop
    {
        private IWebDriver _driver;
        private BrowserHelper _browser;

        //here we eant to creat a getter, typ "prop" and click tab key
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void SetUpTest()
        {   //-we have copied out the 3 line below to "BrowserHelper"
            //_driver = new ChromeDriver();
            //_driver.Manage().Window.Maximize();
            //_driver.Navigate().GoToUrl("http://demo.nopcommerce.com/");

            //let us create an instance of browser
            _browser = new BrowserHelper();//we have to create
            //an instance of the class before we can access it.
            _driver = _browser.LaunchBrowser(); // here we have called it
            
        }

        [TestMethod, TestCategory("SIT")]
        public void CreateANewAccount()
        {
            var createAccount = new CreateAccount(_driver);
            createAccount.RegisterAccount();
        }

        [TestMethod, TestCategory("Smoke")]
        //now we want to read the data file
        //[DataSource("Microsoft.VisualStudio.TestTools.Datasource.CSV",
        //    @"C:\C #\userLoginDetails.csv",
        //    "userLoginDetails.csv",
        //    DataAccessMethod.Sequential)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"C:\Users\admin\Documents\CERTIFICATIONS\Software Testing\Automation Class - Andre\CSharpEssentials2017\ShoppingCartTaskProject\ShoppingCartTaskProject\DataFiles\userLoginDetails.csv",
            "userLoginDetails.csv",
            DataAccessMethod.Sequential)]
        public void ValidLogUserIn()
        {
            //var username = TestContext.DataRow[0] as string;
            //var password = TestContext.DataRow[1] as string;
            //another way to write this
            var username = TestContext.DataRow["username"] as string;
            var password = TestContext.DataRow["password"] as string;


            //the below was copied from above.we
            //want it create account and login
            //var createAccount = new CreateAccount(_driver);
            //// createAccount.RegisterAccount();
            //var loginpage = createAccount.RegisterAccount();
            //loginpage.LoginAsValidUser(username, password);
            //var logOutPage = new LogOutPage(_driver);
            //logOutPage.LogUserOut();

            //we want to reduce the 5 lines of code above
            //using POM
            //
            var createAccount1 = new CreateAccount(_driver);
           // CreateAccount  createAccount1= new CreateAccount(_driver);
            createAccount1
                .RegisterAccount()
                .LoginAsValidUser(username, password)
                .SearchForPc()
                .LogUserOut();


            //as we did for CreateANewAccount() we will do
            //var for loginPage in "LoginPage.cs"

            // var loginPage = new LoginPage(_driver);
            // loginPage.LoginAsValidUser(username, password);

            //var logoutButton = _driver.FindElement(By.ClassName("ico-logout"));
            //Assert.IsTrue(logoutButton.Displayed);
        }

        //    Assert.IsTrue(logoutButton.Displayed); // this check logout

        //  logoutButton = _driver.FindElement(By.ClassName("ico-logout"));
        ////log out button
        ////some code above "logoutButton =" were cut and put in "LoginPage.cs
        //---------------------------------------------------------------//
        //    //button is display after user has looged into account
        //    Thread.Sleep(2000);
        //}
        //---------------------------------------------------------//

        [TestMethod, TestCategory("Smoke")]
        //now we want to read the data file
        //[DataSource("Microsoft.VisualStudio.TestTools.Datasource.CSV",
        //    @"C:\C #\invalidUserLoginDetails.csv",
        //    "invalidUserLoginDetails.csv",
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
            var splitUserName = usernameOrig.Split('-');
            Debug.Assert(passwordOrig !=null, "passwordOrig !=null");
            var splitPassword = passwordOrig.Split('-');

            var username = splitUserName[1];
            var password = splitPassword[1];

          //select login tab from the landing page
          var loginTab = _driver.FindElement(By.ClassName("ico-login"));
          loginTab.Click();

          //enter email
           if (username != null)
           {
               var loginEmail = _driver.FindElement(By.Id("Email"));
              loginEmail.SendKeys(username);
           }

        //    // enter password
          if (password != null)

            {
                var loginPassword = _driver.FindElement(By.Id("Password"));
              loginPassword.SendKeys(password);
           }

          //click login button
           var loginButton = _driver.FindElement(By.ClassName("login-button"));
           loginButton.Click();

           Thread.Sleep(4000);

          }

        [TestMethod]
        [DataSource("System.Data.OleDB",
            @"provider=Microsoft.ACE.OLEDB.12.0;
            Data Source=C:\Users\admin\Documents\CERTIFICATIONS\Software Testing\Automation Class - Andre\CSharpEssentials2017\ShoppingCartTaskProject\ShoppingCartTaskProject\DataFiles\AvailableNotebooks.xlsx;
            Extended Properties='Excel 12.0;HDR=yes';",
            "Sheet1$", DataAccessMethod.Sequential)]

        public void NarrowSearchForNotebook()
        {
            var CPUType = (string) TestContext.DataRow["CPUType"];
            var Memory = (string) TestContext.DataRow["Memory"];
            var Notebook = (string) TestContext.DataRow["MachineName"];
            var Price = (string) TestContext.DataRow["ItemAmount"];

            var computerPage = new ComputerPage(_driver);
            computerPage.SearchForPcAssert();

            Assert.IsTrue(computerPage.ValidateResult(CPUType));
            Assert.IsTrue(computerPage.ValidateResult(Memory));
            // Assert.IsTrue(computerPage.ValidateResult(Notebook));
            // Assert.IsTrue(computerPage.ValidateResult(Notebook));
            Assert.IsTrue(computerPage.ValidateResult(Price));



        }

          [TestCleanup]
        public void TearDownTest()
        {
            
             _browser.CloseBrowser();

        

        }
    }
}