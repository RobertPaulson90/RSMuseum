using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace RSMuseum.MVC.Tests.SeleniumIntegrationTests
{
    public class SeleniumAngularIntegrationTests : IClassFixture<WebDriverTestFixture>
    {
        // Consult Paul W. for questions.
        // XPath knowledge very helpful to understand what's going on here!

        private static IWebDriver _webDriver;
        private readonly string _rootUrl;

        public SeleniumAngularIntegrationTests() {
            _rootUrl = "http://tech-flex.com/RSMuseum-ng"; // Change this to http://localhost:4200 when testing local build
            _webDriver = new ChromeDriver();
        }

        [Fact]
        public void FrontpageLoads() {
            _webDriver.Navigate().GoToUrl(_rootUrl);
            var wdWait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 10)); // Wait a maximum of 10 seconds
            var result = wdWait.Until(d => d.FindElement(By.XPath("//button[@type='submit' and contains(., 'Submit')]")));
            // Check if submit button exists on frontpage
            Assert.NotNull(result);
        }

        [Fact]
        public void VolunteersÓverviewLoads() {
            _webDriver.Navigate().GoToUrl(_rootUrl + "/frivillige/");
            var wdWait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 10));
            var result = wdWait.Until(d => d.FindElement(By.XPath("//td")));
            // Check if tabledata exists
            Assert.NotNull(result);
        }

        //[Fact]
        //public void ApprovalÓverviewLoads() {
        //    //_webDriver.Navigate().GoToUrl(_rootUrl + "/frivillige/");
        //    //var wdWait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 10));
        //    //var result = wdWait.Until(d => d.FindElement(By.XPath("//tr[@_ngcontent-c6]")));
        //    //Assert.NotNull(result);
        //}

        //[Fact]
        //public void ApproveRegistrationWorks() {
        //    //_webDriver.Navigate().GoToUrl(_rootUrl + "/frivillige/");
        //    //var wdWait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 10));
        //    //var result = wdWait.Until(d => d.FindElement(By.XPath("//tr[@_ngcontent-c6]")));
        //    //Assert.NotNull(result);
        //}

        //[Fact]
        //public void DeclineRegistrationWorks() {
        //    //_webDriver.Navigate().GoToUrl(_rootUrl + "/frivillige/");
        //    //var wdWait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 10));
        //    //var result = wdWait.Until(d => d.FindElement(By.XPath("//tr[@_ngcontent-c6]")));
        //    //Assert.NotNull(result);
        //}

        //[Fact]
        //public void SubmitRegistrationWorks() {
        //    //_webDriver.Navigate().GoToUrl(_rootUrl + "/frivillige/");
        //    //var wdWait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 10));
        //    //var result = wdWait.Until(d => d.FindElement(By.XPath("//tr[@_ngcontent-c6]")));
        //    //Assert.NotNull(result);
        //}

        public void Dispose() {
            _webDriver.Quit();
        }
    }
}