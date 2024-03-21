using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QA_Assessment.Elements
{
    internal class Checkout
    {
        IWebDriver WebDriver { get; }

        public Checkout(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement CheckoutInfoPage => WebDriver.FindElement(By.ClassName("checkout_info"));

        public IWebElement FirstName => WebDriver.FindElement(By.Id("first-name"));

        public IWebElement LastName => WebDriver.FindElement(By.Id("last-name"));

        public IWebElement PostalCode => WebDriver.FindElement(By.Id("postal-code"));

        public IWebElement ContinueBtn => WebDriver.FindElement(By.Id("continue"));

        public IWebElement CheckoutSummary => WebDriver.FindElement(By.Id("checkout_summary_container"));

        public IWebElement OrderSummary => WebDriver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div[8]"));

        public IWebElement CompleteOrder => WebDriver.FindElement(By.Id("finish"));

        public IWebElement PurchaseSuccessful => WebDriver.FindElement(By.ClassName("complete-header"));
        public void Continue_to_Order_Page()
        {
            FirstName.SendKeys("Kevin");
            LastName.SendKeys("Olaniyan");
            PostalCode.SendKeys("900107");
            ContinueBtn.Click();
        }

        public string Order_Summary()
        {
            string ordersummary = OrderSummary.Text;

            return ordersummary;
        }

        public string Purchase_Successful()
        {
            string purchasesuccessful = PurchaseSuccessful.Text;

            return purchasesuccessful;
        }
    }

}

