using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Xunit;
using System.Threading;

namespace RSMuseum.MVC.Tests
{
    public class SeleniumTests : IDisposable
    {
        private static IWebDriver wd;

        public SeleniumTests()
        {
             wd = new ChromeDriver();
        }

        [Fact]
        public void TestingSeleniumLoadGoogle()
        {
            wd.Navigate().GoToUrl("http://google.dk");
            var result = wd.FindElement(By.Id("gs_lc0"));
            Assert.NotNull(result);
        }

        public void Dispose()
        {
            wd.Quit();
        }
    }
}
