using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace ShoppingCartTaskProject.Pages
{
    [TestClass]
    public class LoginPage
    {
        private IWebDriver _driver;
  //when you are calling something have a default constructor.
  //it will help you call your class
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void LoginAsValidUser(string username, string password)
        {
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

        }

    }
}
