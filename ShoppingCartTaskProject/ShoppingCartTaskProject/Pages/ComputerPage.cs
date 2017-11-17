using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ShoppingCartTaskProject.Pages
{
    
    public class ComputerPage : BasePage
    {
        public ComputerPage(IWebDriver driver) : base(driver)
        {
            
        }
        private string _cPUType = "Intel Core i5";
        private string _memory = "8 GB";

        public LogOutPage SearchForPc()
        {
            var computerMenu = Driver.FindElement(By.LinkText("Computers"));
        
           // var action = new Actions(Driver);
            var action = new Actions(Driver);
            //To use mouse over-action we will use the code below
            action.MoveToElement(computerMenu).Build().Perform();
            //action.MoveToElement(computerMenu).Perform();
            Driver.FindElement(By.LinkText("Notebooks")).Click();
           // var cpuCheck = Driver.PageSource.Contains(CPU.ToLower());
          // Assert.IsTrue(cpuCheck);
            return new LogOutPage(Driver);
        }

        public void SearchForPcAssert()
        {
            var computerMenu = Driver.FindElement(By.LinkText("Computers"));
            //this code explains the mouseover action
            //and how to select an element
            var action = new Actions(Driver);
            action.MoveToElement(computerMenu).Build().Perform();
            Driver.FindElement(By.LinkText("Notebooks")).Click();

            //Select Notebook by CPU type
            Driver.FindElement(By.LinkText(_cPUType)).Click();

            //Select Notebook by Memory size
            Driver.FindElement(By.LinkText(_memory)).Click();
        }

        public bool ValidateResult(string item)
        {
            return Driver.PageSource.Contains(item);

             
        }
    }
}
