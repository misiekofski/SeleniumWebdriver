using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebdriver.PageObjectPattern.pages
{
    public class HomePage
    {
        private IWebDriver driver; 

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
