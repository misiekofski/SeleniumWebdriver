using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SeleniumWebdriver.BB_Zaawansowane
{
    public class AdvancedSeleniumExample
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }


        [TestCase("Desktop", "C", "2", "12")]
        [TestCase("Server", "Java", "3", "23")]
        [TestCase("Web", "Javascript", "1", "1")]
        public void TestCodeInIt(string category, string language, string valueId, string languageId)
        {
            driver.Url = "https://testpages.herokuapp.com/styled/basic-ajax-test.html";
            IWebElement categoryDropdown = driver.FindElement(By.Id("combo1"));
            SelectElement categorySelect = new SelectElement(categoryDropdown);

            categorySelect.SelectByText(category);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromSeconds(1),
            };

            wait.Until(driver =>
                !driver.FindElement(By.Id("ajaxBusy")).Displayed);

            IWebElement languageDropDown = driver.FindElement(By.Id("combo2"));
            SelectElement languageSelect = new SelectElement(languageDropDown);
            languageSelect.SelectByText(language);

            IWebElement codeInItButton = driver.FindElement(By.Name("submitbutton"));
            codeInItButton.Click();

            IWebElement valueIdElement = driver.FindElement(By.Id("_valueid"));
            StringAssert.AreEqualIgnoringCase(valueIdElement.Text, valueId);

            IWebElement valueLanguageIdElement = driver.FindElement(By.Id("_valuelanguage_id"));
            StringAssert.AreEqualIgnoringCase(valueLanguageIdElement.Text, languageId);
        }

        [Test]
        public void TestDynamicTable()
        {
            driver.Url = "https://testpages.herokuapp.com/styled/tag/dynamic-table.html";
            IWebElement tableData = driver.FindElement(By.XPath("//summary"));
            tableData.Click();

            IWebElement textArea = driver.FindElement(By.Id("jsondata"));
            textArea.Click();
            textArea.Clear();

            string tableText = "[{\"name\" : \"Bob\", \"age\" : 20}," +
                " {\"name\": \"George\", \"age\" : 42}," +
                " {\"name\": \"John Wick\", \"age\": 44}]";
            textArea.SendKeys(tableText);

            IWebElement refreshTableButton = driver.FindElement(By.Id("refreshtable"));
            refreshTableButton.Click();

            IWebElement tableElement = driver.FindElement(By.Id("dynamictable"));
            IList<IWebElement> tableRows = tableElement.FindElements(By.XPath("//tr"));
            Assert.AreEqual(4, tableRows.Count);
        }


        [Test]
        public void TestMouseOverDiv()
        {
            driver.Url = "https://testpages.herokuapp.com/styled/expandingdiv.html";
            IWebElement expandingDiv = driver.FindElement(By.CssSelector(".expand"));
            Actions action = new Actions(driver);
            action.MoveToElement(expandingDiv);
            action.Perform();

            var linkToClick = expandingDiv.FindElement(By.XPath(".//a"));
            linkToClick.Click();

            var header = driver.FindElement(By.XPath("//h1"));
            StringAssert.AreEqualIgnoringCase(header.Text, "You clicked the link in the expanding div");
        }

        [Test]
        public void TestDynamicButtons()
        {

            driver.Url = "https://testpages.herokuapp.com/styled/dynamic-buttons-disabled.html";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromSeconds(1),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement startButton = wait.Until(driver =>
                driver.FindElement(By.Id("button00")));

            startButton.Click();

            var oneButton = driver.FindElement(By.Id("button01"));
            wait.Until(driver => oneButton.Enabled);
            oneButton.Click();

            var twoButton = driver.FindElement(By.Id("button02"));
            wait.Until(driver => twoButton.Enabled);
            twoButton.Click();

            var threeButton = driver.FindElement(By.Id("button03"));
            wait.Until(driver => threeButton.Enabled);
            threeButton.Click();

            var buttonMessage = driver.FindElement(By.Id("buttonmessage"));
            StringAssert.AreEqualIgnoringCase(buttonMessage.Text, "All buttons clicked");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
