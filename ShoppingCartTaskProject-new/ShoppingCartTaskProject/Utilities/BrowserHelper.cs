using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ShoppingCartTaskProject.Utilities
{
    [TestClass]
    public class BrowserHelper
    {
        private IWebDriver _driver;

        public IWebDriver LaunchBrowser()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://demo.nopcommerce.com/");
            return _driver; //this is saying once you are done with this
            //return it and let us use it somehwre else

        }

        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
