using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace ShoppingCartTaskProject.Pages
{
    [TestClass]
    public class LogOutPage:BasePage
    {
       
        public LogOutPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly By _logOutButton = By.ClassName("ico-logout");

        public void LogUserOut()
        {
            Driver.FindElement(_logOutButton).Click();
        }
    }
}
