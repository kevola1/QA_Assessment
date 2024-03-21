using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Assessment.Elements;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace QA_Assessment
{
    [TestFixture]
    public class SauceDemo
    {
        private IWebDriver driver;
        private LoginAndLogout loginPage;
        private Products productPage;
        private Cart cartPage;
        private Checkout checkoutPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            loginPage = new LoginAndLogout(driver);
            productPage = new Products(driver);
            cartPage = new Cart(driver);
            checkoutPage = new Checkout(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void BuyTshirt()
        {
            loginPage.Login();

            //Verify that user is logged in successfully
            Assert.That(productPage.ProductContainer.Displayed, Is.True, "Element is not displayed.");

            string productPageURL = "https://www.saucedemo.com/inventory.html";

            Assert.That(productPage.producstPageUrl(), Is.EqualTo(productPageURL));

            Thread.Sleep(5000);
            //Verify that Tshirt page is displayed 
            productPage.SelectedTshirt.Click();

            Thread.Sleep(3000);

            string tshirt_url = "https://www.saucedemo.com/inventory-item.html?id=1";

           Assert.That(driver.Url, Is.EqualTo(tshirt_url));

           Assert.That(productPage.TshirtDetailsPage.Displayed, Is.True, "Product Details Page is not Displayed");

          
            //Verify that Tshirt is added to cart successfully
            Assert.That(productPage.TshirtText, Is.EqualTo("Sauce Labs Bolt T-Shirt"));

            productPage.AddTshirtToCart.Click();

            productPage.navigateToCart();

            //Verify that the cart page is displayed
            Assert.That(cartPage.cartPage.Displayed, Is.True, "Cart page is not displayed");

            
            string ItemDescription = "Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.";
            
            string ItemPrice = "$15.99";
            
            string ItemName = "Sauce Labs Bolt T-Shirt";

            Assert.That(cartPage.SelectedTshirtName, Is.EqualTo(ItemName));
            
            Assert.That(cartPage.SelectedTshirtPrice, Is.EqualTo(ItemPrice));
            
            Assert.That(cartPage.SelectedTshirtDescription, Is.EqualTo(ItemDescription));

            cartPage.Checkout.Click();

            Thread.Sleep(5000);
            //Verify that checkout page info is displayed
            Assert.That(checkoutPage.CheckoutInfoPage.Displayed, Is.True, "Checkout Information is not Displayed");

            checkoutPage.Continue_to_Order_Page();

            //Verify that order summary page is displayed showing correct details
            Thread.Sleep(3000);
            string ItemDescription2 = "Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.";
            
            string ItemTotalPrice = "Total: $17.27";
            
            string ItemName2 = "Sauce Labs Bolt T-Shirt";

            Assert.That(checkoutPage.CheckoutSummary.Displayed, Is.True, "Checkout Summary is Displayed");

            Assert.That(cartPage.SelectedTshirtName, Is.EqualTo(ItemName2));

            Assert.That(checkoutPage.Order_Summary, Is.EqualTo(ItemTotalPrice));

            Assert.That(cartPage.SelectedTshirtDescription, Is.EqualTo(ItemDescription2));

            Thread.Sleep(3000);

            checkoutPage.CompleteOrder.Click();

            Thread.Sleep(3000);

            //Verify order confirmation page is displayed
            string CheckoutURL = "https://www.saucedemo.com/checkout-complete.html";

            Assert.That(checkoutPage.Purchase_Successful, Is.EqualTo("Thank you for your order!"));

            Assert.That(driver.Url, Is.EqualTo(CheckoutURL));

            Thread.Sleep(4000);

            loginPage.Logout();

            // Verify user is logged out successfully

            string LoginPageURL = "https://www.saucedemo.com/";

            driver.Navigate().GoToUrl("https://www.saucedemo.com/checkout-complete.html");

            Assert.That(driver.Url, Is.EqualTo(LoginPageURL));

        }
    }
}