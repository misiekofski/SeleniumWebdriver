using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebdriver.PageObjectPattern.pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebdriver.PageObjectPattern.tests
{
    public class RegisterUserTest
    {
        private IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void TestUserRegistration()
        {
            driver.Url = "https://react-redux.realworld.io/#/register";

            var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            string email = $"dobrzycki+{timestamp}@gmail.com";
            string username = "John Wick";
            string password = "Daisy";

            RegisterPage registerPage = new RegisterPage(driver);
            registerPage.CreateUser(username, email, password);
            HomePage homePage = new HomePage(driver);
            StringAssert.AreEqualIgnoringCase(username, homePage.getUserName());
        }
    }
}
