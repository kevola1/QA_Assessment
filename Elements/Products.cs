using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QA_Assessment.Elements
{
    internal class Products
    {
        public IWebDriver WebDriver { get; }

        public Products(IWebDriver driver)
        {
            WebDriver = driver;

        }
        public IWebElement SelectedTshirt => WebDriver.FindElement(By.LinkText("Sauce Labs Bolt T-Shirt"));
        public IWebElement SelectedTshirtText => WebDriver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div[2]/div[1]"));

        public IWebElement ProductContainer => WebDriver.FindElement(By.Id("inventory_container"));

        public IWebElement TshirtDetailsPage => WebDriver.FindElement(By.ClassName("inventory_details"));

        public IWebElement AddTshirtToCart => WebDriver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));

        public IWebElement CartLink => WebDriver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[3]/a"));

        public string producstPageUrl()
        {
            return WebDriver.Url;
        }

        public void navigateToCart()
        {
            CartLink.Click();
            Thread.Sleep(3000);
        }

        public string TshirtText()
        {
            string BoltShirt = SelectedTshirtText.Text;

            return BoltShirt;

        }

    }
}
