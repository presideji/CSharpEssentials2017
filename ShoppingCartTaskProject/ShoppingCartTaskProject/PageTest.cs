using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ShoppingCartTaskProject
{
    [TestClass]
    public class PageTest
    {
        private IWebDriver _driver;

        [TestInitialize] // this iwll be the 1st to run
        public void SetUpTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
           // _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            // _driver.Navigate().GoToUrl("http://www.next.co.uk/");
            _driver.Navigate().GoToUrl("http://demo.nopcommerce.com/");
        }


        [TestMethod, TestCategory("Smoke")]
        public void RegisterAccount()
        {
            //click on register button
            var registerButton = _driver.FindElement(By.ClassName("ico-register"));
            registerButton.Click();
            
            //Assert register page is displayed
            var registerPage = _driver.Title;
            Assert.AreEqual(registerPage, "nopCommerce demo store. Register");

            // click Gender
            var maleGender = _driver.FindElement(By.Id("gender-male"));
            maleGender.Click();

            //enter firstname
            var firstName = _driver.FindElement(By.Id("FirstName"));
            firstName.SendKeys("Dejo");

            //enter lastname
            var lastName = _driver.FindElement(By.Id("LastName"));
            lastName.SendKeys("Akin");

            //select day of Birth
            var dayOfBirth = _driver.FindElement(By.Name("DateOfBirthDay"));
            var selectDayOfBirth = new SelectElement(dayOfBirth);
            selectDayOfBirth.SelectByIndex(5);//you are counting from the
            //dates

            //select Month of Birth
            var monthOfBirth = _driver.FindElement(By.Name("DateOfBirthMonth"));
            var selectMonthOfBirth = new SelectElement(monthOfBirth);
            selectMonthOfBirth.SelectByValue("6");//use"6" bcos it is a string

            //select year of Birth
            var yearOfBirth = _driver.FindElement(By.Name("DateOfBirthYear"));
            var selectYearOfBirth = new SelectElement(yearOfBirth);
            selectYearOfBirth.SelectByText("1980");

            //enter email
            var email = _driver.FindElement(By.Id("Email"));
            email.SendKeys("kala@yahoo.com");

            //tick newsletter checkbox. this is if the box is not ticked
            var newsletterBox = _driver.FindElement(By.Id("Newsletter"));
            /**
             * This code will be standard if the 
             * checkbox for newsletter was never ticked by default
             */
             //newletterBox.Click();
            if (!newsletterBox.Selected) // the exclaimation in the front
                // meand if the "newsletter tick box is
                //not selected then click it, if click move one
            {
                newsletterBox.Click();
            }

            //enter password
            var password = _driver.FindElement(By.Id("Password"));
            password.SendKeys("welcome123");

            //confirm password
            var passwordConfirm = _driver.FindElement(By.Id("ConfirmPassword"));
            passwordConfirm.SendKeys("welcome123");

            //click register button
            var creatAccountButton = _driver.FindElement(By.Id("register-button"));
            creatAccountButton.Click();
            

        }


        [TestMethod, TestCategory("UAT"),]
        public void ConfirmUserOnHomePage()
        {

        }




        [TestMethod, TestCategory("SmokeDay3")]
        public void GetPageTitle()
        {
            //Console.WriteLine("This is a test to get the page title");
            var pageTitle = _driver.Title;
            //when your page title is too long use the below instead of the above
            // var pageTitle = _driver.Title.Contains("Kids Clothes & Homeware"); //-look at
            //this next class not running
            //Assert.AreEqual(pageTitle, "My Store", "The expected and actual do not match");//use "assert" 
            //to confirm a page. grab title of the page
            //and confirm it is "my store"
            Assert.AreEqual(pageTitle, "Next Official Site: Online Fashion, Kids Clothes & Homeware", "the expects and actual do not match");
        }

        [TestMethod, TestCategory("UATDay3"),]
        public void CheckForCookies()
        {
            var allcookies = _driver.Manage().Cookies.AllCookies;//get me all the cookies
            //available put them in " allcookies"
            foreach (var cookie in allcookies) // i will look through all cookies
                                               //one by one
            {
                Console.WriteLine("This list of cookie are {0}", cookie.ToString());//this will print all cookies

            }
        }

        
        [TestMethod]
        public void ConfirmUserOnHomePage1()
        {
            //now we want to confirm we are on the homepage
            var contactUs = _driver.PageSource.ToLower().Contains("Contact Us".ToLower());
            //the above means go to page source find "contact us" change it to lower case
            //when you have done that put all in "contactus"
            Assert.IsTrue(contactUs);// i have check contact us i sthere but need to confirm
            //it is true

        }
        
        [TestMethod]
        public void CallAnotherTest()
        {
            Console.WriteLine("This is another test");
        }

        [TestMethod, TestCategory("SmokeDay4")]
        public void RegisterAccountDay4()
        {
            //declare wait method
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            //runn but wait for element for 10sec

            _driver.FindElement(By.ClassName("login")).Click();
            var signInPageTitle = _driver.Title;
            Assert.AreEqual(signInPageTitle.ToLower(), "Login - My Store".ToLower());

            //select email field and send email address
            var email = _driver.FindElement(By.Id("email_create"));
            email.SendKeys("kala@yahoo.com");

            //find submit button and click it
            var submitButton = _driver.FindElement(By.Id("SubmitCreate"));
            submitButton.Click();

            ////select the radio button for Mr
            //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("id_gender1")));
            //var selectMr = _driver.FindElement(By.Id("id_gender1"));
            //selectMr.Click();

            ////enter firstname
            //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("customer_firstname")));
            //var firstName = _driver.FindElement(By.Id("customer_firstname"));
            //firstName.SendKeys("dejo");

            ////----   //select day of birth
            //   var dayOfBirth = _driver.FindElement(By.Id("days"));
            //   var selectDayOfBirth = new SelectElement(dayOfBirth);
            //   selectDayOfBirth.SelectByValue("2");

            //   //select month of Birth
            //   wait.Until(ExpectedConditions.ElementIsVisible(By.Id("months")));
            //   var monthOfBirth = _driver.FindElement(By.Id("months"));
            //   var selectMonthOfBirth = new SelectElement(monthOfBirth);
            //   selectMonthOfBirth.SelectByIndex(4);

            //   //select year of birth
            //   wait.Until(ExpectedConditions.ElementIsVisible(By.Id("years")));
            //   var yearOfBirth = _driver.FindElement(By.Id("years"));
            //   var selectYearOfBirth = new SelectElement(yearOfBirth);
            //   selectYearOfBirth.SelectByValue("2");
            // 

            //select checkbox
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("newsletter")));
            var newsletterSignUp = _driver.FindElement(By.Id("newsletter"));
            newsletterSignUp.Click();

        }

        [TestMethod, TestCategory("UATDay4"),]
        public void ConfirmUserOnHomePageDay4()
        {
            var contactUs = _driver.PageSource.ToLower().Contains("header_logo".ToLower());
            Assert.IsTrue(contactUs);
        }



        [TestCleanup] // clear up test retrun it to original state
        public void TearDownTest()
        {
            Thread.Sleep(10000);
            _driver.Quit();//any browser open by automation test only close it down
                           // _driver.Close(); // it will only close the most recent browser open
        }
    }
}
