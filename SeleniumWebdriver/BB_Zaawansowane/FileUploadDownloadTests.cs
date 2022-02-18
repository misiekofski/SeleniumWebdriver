using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SeleniumWebdriver.BB_Zaawansowane
{
    public class FileUploadDownloadTests
    {
        private IWebDriver driver;
        [SetUp]
        public void SetUp()
        {           
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", @"C:\downloads\");
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            driver = new ChromeDriver(options);
        }

        [Test]
        public void UploadFileTest()
        {
            driver.Url = "https://testpages.herokuapp.com/styled/file-upload-test.html";

            var fileInput = driver.FindElement(By.Id("fileinput"));
            string pathToFile = @".\files\kotek.jpg";
            fileInput.SendKeys(Path.GetFullPath(pathToFile));

            var imageCheckbox = driver.FindElement(By.Id("itsanimage"));
            imageCheckbox.Click();
            var uploadButton = driver.FindElement(By.Name("upload"));
            uploadButton.Click();

            string confirmationMessage = driver.FindElement(By.XPath("//h2")).Text;
            StringAssert.AreEqualIgnoringCase(confirmationMessage, "You uploaded this image:");
            string uploadedFileName = driver.FindElement(By.Id("uploadedfilename")).Text;
            StringAssert.AreEqualIgnoringCase(uploadedFileName, "kotek.jpg");
        }

        [Test]
        public void DownloadTest()
        {
            driver.Url = "https://testpages.herokuapp.com/styled/download/download.html";
            IWebElement directDownloadButton = driver.FindElement(By.Id("direct-download"));
            directDownloadButton.Click();

            Thread.Sleep(1000);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
