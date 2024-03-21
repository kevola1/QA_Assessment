using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QA_Assessment.Elements
{
    internal class Cart
    {
        IWebDriver WebDriver { get; }

        public Cart(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
        public IWebElement TshirtDescription => WebDriver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[3]/div[2]/div[1]"));

        public IWebElement TshirtName => WebDriver.FindElement(By.LinkText("Sauce Labs Bolt T-Shirt"));

        public IWebElement TshirtPrice => WebDriver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[3]/div[2]/div[2]/div"));

        public IWebElement cartPage => WebDriver.FindElement(By.Id("cart_contents_container"));

        public IWebElement Checkout => WebDriver.FindElement(By.Id("checkout"));

        public string SelectedTshirtPrice()
        {
            string selectedtshritprice = TshirtPrice.Text;

            return selectedtshritprice;

        }
        public string SelectedTshirtDescription()
        {
            string selectedtshritdescription = TshirtDescription.Text;

            return selectedtshritdescription;

        }

        public string SelectedTshirtName()
        {
            string selectedtshritname = TshirtName.Text;

            return selectedtshritname;

        }
    }
}
