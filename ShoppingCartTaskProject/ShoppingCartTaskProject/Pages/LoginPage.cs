using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace ShoppingCartTaskProject.Pages
{
    [TestClass]
    public class LoginPage : BasePage
    {
        //we comment some code out bcos "basepage" is linked above
        //      private IWebDriver _driver;
        ////when you are calling something have a default constructor.
        ////it will help you call your class
        //      public LoginPage(IWebDriver driver)
        //      {
        //          _driver = driver;
        //      }
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public ComputerPage LoginAsValidUser(string username, string password)//the log in code from Ecommerce Shop
            //is pasted below
        {
            //select login tab from the landing page
            var loginTab = Driver.FindElement(By.ClassName("ico-login"));
            loginTab.Click();

            //enter email
            var loginEmail = Driver.FindElement(By.Id("Email"));
            // loginEmail.SendKeys("kala@yahoo.com");
            loginEmail.SendKeys(username);

            //enter password
            var loginPassword = Driver.FindElement(By.Id("Password"));
            // loginPassword.SendKeys("welcome123");
            loginPassword.SendKeys(password);

            //click login button
            var loginButton = Driver.FindElement(By.ClassName("login-button"));
            loginButton.Click();
            Thread.Sleep(3000);
            return new ComputerPage(Driver);


        }

        
    }
}
