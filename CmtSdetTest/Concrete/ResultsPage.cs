using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CmtSdetTest.Abstract;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CmtSdetTest.Concrete
{
    public class ResultsPage : BaseCTMJourneyPage
    {
        private FirefoxDriver _driver;

        private readonly string _electricSupplierXpath = "/html/body/div/div/main/section[1]/div/ul/li[1]/div[1]";
        private readonly string _electricTariffXpath = "/html/body/div/div/main/section[1]/div/ul/li[1]/div[2]";
        private readonly string _gasSupplierXpath = "/html/body/div/div/main/section[1]/div/ul/li[2]/div[1]";
        private readonly string _gasTariffXpath = "/html/body/div/div/main/section[1]/div/ul/li[2]/div[2]";
        private readonly string _paymentMethodXpath = "/html/body/div/div/main/section[1]/div/ul/li[3]/div";
        private readonly string _annualProjectXpath = "/html/body/div/div/main/section[1]/div/ul/li[4]/div/span";
        private readonly string _resultsPageHeader = "/html/body/div/div/main/section[3]/h2";

        public ResultsPage() : base()
        {
            _driver = ScenarioContext.Current.Get<FirefoxDriver>("driver");
        }

        public string GetCurrentUrl()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            try
            {
                IWebElement myDynamicElement = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.XPath(_resultsPageHeader)));
            }
            catch (Exception e)
            {
                
            }
            return _driver.Url;
        }
    }

}
