using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ShoppingCartTaskProject
{
   //- [TestClass]
    public class CreateAccount
    {
        private readonly IWebDriver _driver;

        //-[TestInitialize] // this will be the 1st to run
        //public void SetUpTest()
        //{
        //    _driver = new ChromeDriver();
        //    _driver.Manage().Window.Maximize();
        //    _driver.Navigate().GoToUrl("http://demo.nopcommerce.com/");
        //}
        
           //-create a constructor of IWebDriver
        public CreateAccount(IWebDriver driver)
        {
            _driver = driver;
        }

       // [TestMethod, TestCategory("Smoke")]
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

            //tick newsletter checkbox
            var newsletterBox = _driver.FindElement(By.Id("Newsletter"));
            /**
             * This code below would be standard if the checkbox
             * for newsletter was never ticked by default
             */
            if (!newsletterBox.Selected)
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
            Thread.Sleep(3000);
        }

        [TestCleanup]
        public void TearDownTest()
        {
            _driver.Quit();

        }
    }
}
