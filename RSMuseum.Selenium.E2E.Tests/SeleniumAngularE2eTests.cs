using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace RSMuseum.Selenium.E2E.Tests
{
    public class SeleniumAngularE2eTests : IClassFixture<WebDriverTestFixture>
    {
        // A bit of voodoo magic in here. Consult Paul W. for questions
        // XPath knowledge helpful to understand what's going on

        private readonly WebDriverTestFixture _wdFixture;
        private readonly string _rootUrl = "http://tech-flex.com/RSMuseum-ng"; // Change this to http://localhost:4200 when testing local build
        private readonly TimeSpan _timeSpan = new TimeSpan(0, 0, 10); // Give tests 10 seconds to complete

        public SeleniumAngularE2eTests(WebDriverTestFixture wdFixture) {
            // This class inherits from the IClassFixture interface, so all tests are executed in the same browser.
            // This also means an instance of WebDriverTestFixture is automatically injected in here, thanks to Selenium
            // https://xunit.github.io/docs/shared-context.html
            _wdFixture = wdFixture;
        }

        [Fact]
        public void FrontpageLoads() {
            _wdFixture.WebDriver.Navigate().GoToUrl(_rootUrl);
            var wdWait = new WebDriverWait(_wdFixture.WebDriver, _timeSpan); // Wait a maximum of 10 seconds
            var result = wdWait.Until(d => d.FindElement(By.XPath("//button[@type='submit' and contains(., 'Submit')]")));
            // Check if submit button exists on frontpage
            Assert.NotNull(result);
        }

        [Fact]
        public void VolunteersÓverviewLoads() {
            _wdFixture.WebDriver.Navigate().GoToUrl(_rootUrl + "/frivillige");
            var wdWait = new WebDriverWait(_wdFixture.WebDriver, _timeSpan);

            // Check if tabledata exists
            var result = wdWait.Until(d => d.FindElement(By.XPath("//td")));
            Assert.NotNull(result);
        }

        [Fact]
        public void ApprovalÓverviewLoads() {
            _wdFixture.WebDriver.Navigate().GoToUrl(_rootUrl + "/registrering-godkendelse");
            var wdWait = new WebDriverWait(_wdFixture.WebDriver, _timeSpan);

            // Check if tabledata exists
            var result = wdWait.Until(d => d.FindElement(By.XPath("//td")));
            Assert.NotNull(result);
        }

        [Fact]
        public void StatisticsOverviewLoads() {
            _wdFixture.WebDriver.Navigate().GoToUrl(_rootUrl + "/statistik");
            var wdWait = new WebDriverWait(_wdFixture.WebDriver, _timeSpan);

            // Discover the datepicker and open it
            var datepicker = wdWait.Until(d => d.FindElement(By.XPath("//input")));
            new Actions(_wdFixture.WebDriver)
                .Click(datepicker)
                .Perform();

            // Discover the 1st day of the month and click it
            var date = wdWait.Until(d => d.FindElement(By.XPath("//span[contains(., '1')]")));
            new Actions(_wdFixture.WebDriver)
                .Click(date)
                .Perform();

            // Check if canvas exists
            var result = wdWait.Until(d => d.FindElement(By.XPath("//canvas")));
            Assert.NotNull(result);
        }

        [Fact]
        public void ApproveRegistrationWorks() {
            // TODO
        }

        [Fact]
        public void DeclineRegistrationWorks() {
            // TODO
        }

        [Fact]
        public void SubmitRegistrationWorks() {
            // TODO
        }
    }
}