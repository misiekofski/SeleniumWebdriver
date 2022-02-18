using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebdriver.PageObjectPattern.pages
{
    public class RegisterPage
    {
        private IWebDriver driver;

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By userNameLocator => By.XPath("//form//input[@type='text']");
        private By emailLocator => By.XPath("//form//input[@type='email']");
        private By passwordLocator => By.XPath("//form//input[@type='password']");

        public void CreateUser(string username, string email, string password)
        {
            driver.FindElement(userNameLocator).SendKeys(username);
            driver.FindElement(emailLocator).SendKeys(email);
            driver.FindElement(passwordLocator).SendKeys(password);
        }
    }
}
