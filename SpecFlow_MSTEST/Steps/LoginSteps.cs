using System;
using OpenQA.Selenium;
using SpecFlow_MSTEST.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow_MSTEST.Steps
{
    [Binding]
    public class LoginSteps
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public LoginSteps(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [Given(@"I navigate to the application with the following browsers")]
        public void GivenINavigateToTheApplicationWithTheFollowingBrowsers(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            driver = _scenarioContext.Get<WebDriverLibrary>("WebDriverLibrary").Setup((string)data.Browsers);
            driver.Url = "http://eaapp.somee.com";
        }
        
        [Given(@"I click the login link")]
        public void GivenIClickTheLoginLink()
        {
            driver.FindElement(By.LinkText("Login")).Click();
        }
        
        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driver.FindElement(By.Id("UserName")).SendKeys(data.UserName);
            driver.FindElement(By.Id("Password")).SendKeys(data.Password);
        }
        
        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            driver.FindElement(By.CssSelector(".btn-default")).Click();
        }
    }
}
