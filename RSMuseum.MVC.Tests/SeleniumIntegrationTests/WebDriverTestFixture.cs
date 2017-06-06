using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RSMuseum.MVC.Tests.SeleniumIntegrationTests
{
    internal class WebDriverTestFixture
    {
        private static IWebDriver _webDriver;
        private readonly string _rootUrl;

        public WebDriverTestFixture(string rootUrl) {
            _rootUrl = rootUrl; // Change this to http://localhost:4200 when testing local build
            _webDriver = new ChromeDriver();
        }
    }
}