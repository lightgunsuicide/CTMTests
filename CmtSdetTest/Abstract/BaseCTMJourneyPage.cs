using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace CmtSdetTest.Abstract
{
    public abstract class BaseCTMJourneyPage
    {
        private FirefoxDriver _driver;
        private string _headingId = "main-heading";

        public BaseCTMJourneyPage() {
            _driver = ScenarioContext.Current.Get<FirefoxDriver>("driver");
        }

        public string GetPageHeading() {

            return _driver.FindElementById(_headingId).Text;
        }
    }
}
