using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SpecFlow_MSTEST.Drivers
{
    internal class WebDriverLibrary
    {
        private readonly ScenarioContext _scenarioContext;

        public WebDriverLibrary(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IWebDriver Setup(string browserName)
        {
            dynamic capability = GetBrowserOptions(browserName);
            var driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability.ToCapabilities());

            _scenarioContext.Set(driver, "WebDriver");

            return driver;
        }

        private dynamic GetBrowserOptions(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    return new ChromeOptions();
                case "firefox":
                    return new FirefoxOptions();
                default:
                    return new ChromeOptions();
            }
            if (browserName == "MicrosoftEdge")
                return new EdgeOptions();
            if (browserName == "Safari")
                return new SafariOptions();
        }
    }
}
