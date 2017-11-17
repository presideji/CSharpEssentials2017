using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace ShoppingCartTaskProject.Pages
{
    [TestClass]
    public class BasePage
    {
        protected IWebDriver Driver;

       public BasePage(IWebDriver driver)
       {
           Driver = driver;
            
       }
    }
}
