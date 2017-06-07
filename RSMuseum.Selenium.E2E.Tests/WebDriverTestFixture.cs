using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RSMuseum.Selenium.E2E.Tests
{
    public class WebDriverTestFixture : IDisposable
    {
        public readonly IWebDriver WebDriver = new ChromeDriver();

        public WebDriverTestFixture() {
        }

        public void Dispose() {
            WebDriver.Quit();
        }
    }
}