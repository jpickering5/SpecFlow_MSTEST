using OpenQA.Selenium;
using SpecFlow_MSTEST.Drivers;
using TechTalk.SpecFlow;
namespace SpecFlow_MSTEST.Hooks
{
    [Binding]
    internal class TestInitialize
    {
        private readonly ScenarioContext _scenarioContext;

        public TestInitialize(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void StartWebDriver()
        {
            WebDriverLibrary webDriverLibrary = new WebDriverLibrary(_scenarioContext);
            _scenarioContext.Set(webDriverLibrary, "WebDriverLibrary");
        }

        [AfterScenario]
        public void KillDriver() => _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        
    }
}
