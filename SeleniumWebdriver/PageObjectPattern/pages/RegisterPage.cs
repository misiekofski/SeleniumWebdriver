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
        private IWebElement userNameInput => driver.FindElement(userNameLocator);

        private By emailLocator => By.XPath("//form//input[@type='email']");
        private IWebElement emailInput => driver.FindElement(emailLocator);

        private By passwordLocator => By.XPath("//form//input[@type='password']");
        private IWebElement passwordInput => driver.FindElement(passwordLocator);

        private By buttonLocator => By.XPath("//button[@type='submit']");
        private IWebElement registerButton => driver.FindElement(buttonLocator);

        public void CreateUser(string username, string email, string password)
        {
            userNameInput.SendKeys(username);
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            registerButton.Click();
        }
    }
}
