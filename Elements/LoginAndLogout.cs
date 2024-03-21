using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QA_Assessment.Elements
{
    internal class LoginAndLogout
    {
        IWebDriver WebDriver { get; }

        public LoginAndLogout(IWebDriver webDriver)
        {
            WebDriver = webDriver;

        }

        public IWebElement username => WebDriver.FindElement(By.Id("user-name"));

        public IWebElement password => WebDriver.FindElement(By.Id("password"));

        public IWebElement Menu => WebDriver.FindElement(By.Id("react-burger-menu-btn"));

        public IWebElement logout => WebDriver.FindElement(By.Id("logout_sidebar_link"));

        public IWebElement login => WebDriver.FindElement(By.Id("login-button"));

        public void Login()
        {
            username.SendKeys("standard_user");
            password.SendKeys("secret_sauce");
            login.SendKeys(Keys.Enter);

            Thread.Sleep(3000);

        }

        public void Logout()
        {
            Menu.Click();
            logout.Click();
        }


    }
}
