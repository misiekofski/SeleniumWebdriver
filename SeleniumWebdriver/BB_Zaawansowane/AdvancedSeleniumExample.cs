using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

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


        [Test]
        public void TestCodeInIt()
        {
            driver.Url = "https://testpages.herokuapp.com/styled/basic-ajax-test.html";
            IWebElement codeInItButton = driver.FindElement(By.Name("submitbutton"));
            codeInItButton.Click();

            IWebElement valueId = driver.FindElement(By.Id("_valueid"));
            StringAssert.AreEqualIgnoringCase(valueId.Text, "1");
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
            Console.Write(tableRows.Count);
        }
    }
}
