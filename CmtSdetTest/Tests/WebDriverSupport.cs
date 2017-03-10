using System;
using System.Configuration;
using TechTalk.SpecFlow;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CmtSdetTest.Concrete;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecRun;
using Tests.Models;

namespace Tests
{
    [Binding]
    public class WebDriverSupport
    { 
        //todo: remove all artifacts of previous dependency injection method, starting with the below, if time runs out      
        //private readonly IObjectContainer _objectContainer;

        //public WebDriverSupport(IObjectContainer objectContainer)
        //{
        //   this._objectContainer = _objectContainer;
        //}

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var driver = new FirefoxDriver();
            ScenarioContext.Current.Add("driver", driver);
        }

        [AfterScenario]
        public void EndWebDriver()
        {
           var driver = ScenarioContext.Current.Get<FirefoxDriver>("driver");
                driver.Quit();
            driver.Dispose();
        }

        [BeforeScenario("gasUserJourney")]
        public void SetUpGasUser()
        {
           var gasUser = new GasUser();
            ScenarioContext.Current.Add("User", gasUser);;
        }

        [BeforeScenario("electricUserJourney")]
        public void SetUpElectricUser()
        {
            var electricUser = new ElectricUser();
            ScenarioContext.Current.Add("User", electricUser);
        }

        [BeforeScenario("bothUserJourney")]
        public void SetUpBothUser()
        {
            var bothUser = new ElectricAndGasUser();
            ScenarioContext.Current.Add("User", bothUser);
        }

        public SupplierPage OpenCTMEnergyJourney() {
            var driver = ScenarioContext.Current.Get<FirefoxDriver>("driver");
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("basePageUrl"));
            return new SupplierPage();
        }
    }
}