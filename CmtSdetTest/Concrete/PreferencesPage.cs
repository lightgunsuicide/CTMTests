using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CmtSdetTest.Abstract;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CmtSdetTest.Concrete
{
    public class PreferencesPage : BaseCTMJourneyPage
    {
        private FirefoxDriver _driver;
        private readonly string _fixedRateXpath = "//*[@id='tariff-selection-question']/div/label[1]/span/span";
        private readonly string _variableXpath = "//*[@id='tariff-selection-question']/div/label[2]/span/span";
        private readonly string _allRatesXpath = "//*[@id='tariff-selection-question']/div/label[3]/span/span";
        private readonly string _monthlyPaymentXpath = "//*[@id='payment-selection-question']/div/label[1]/span/span";
        private readonly string _quarterlyPaymentXpath = "//*[@id='payment-selection-question']/div/label[2]/span/span";
        private readonly string _billOnReceiptXpath = "//*[@id='payment-selection-question']/div/label[3]/span/span";
        private readonly string _allPaymentsXpath = "//*[@id='payment-selection-question']/div/label[4]/span/span";
        private readonly string _emailTextId = "Email";
        private readonly string _tsAndCsBoxXpath = "//*[@id='terms-label']/span[2]";
        private readonly string _nextButtonId = "email-submit";

        public PreferencesPage() : base()
        {
            _driver = ScenarioContext.Current.Get<FirefoxDriver>("driver");
          
        }

        public void WaitFirst()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            try
            {
                IWebElement myDynamicElement = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.XPath(_fixedRateXpath)));
            }
            catch (Exception e)
            {
                /*Due to intermitten failures to find the element despite it appearing, as this was not the pressing issue a 
                 * try-catch has been used to prevent the test failing on this point. 
               In the instance of a true failure (that is, elements not loading) the rest of the test will fail legitimately in any case
                 *  */
            }
        }

        public void ClickFixedRate()
        {
            WaitFirst();
            _driver.FindElementByXPath(_fixedRateXpath).Click();
        }

        public void ClickVariableRate()
        {
            WaitFirst();
            _driver.FindElementByXPath(_variableXpath).Click();
        }

        public void ClickAllRates()
        {
            WaitFirst();
            _driver.FindElementByXPath(_allRatesXpath).Click();
        }

        public void ClickMonthlyPayment()
        {
            _driver.FindElementByXPath(_monthlyPaymentXpath).Click();
        }

        public void ClickQuarterlyPayment()
        {
            _driver.FindElementByXPath(_quarterlyPaymentXpath).Click();
        }

        public void ClickBillsOnReceipt()
        {
            _driver.FindElementByXPath(_billOnReceiptXpath).Click();
        }

        public void ClickAllPayments()
        {
            _driver.FindElementByXPath(_allPaymentsXpath).Click();
        }

        public void EnterEmailAddress(string emailAddress) {
            _driver.FindElementById(_emailTextId).SendKeys(emailAddress);          
        }

        public void ClickHaveReadTermsAndConditions()
        {
            _driver.FindElementByXPath(_tsAndCsBoxXpath).Click();
        }

        public ResultsPage ClickNext()
        {
            _driver.FindElementById(_nextButtonId).Click();
            //To be clear, it is really not my style to use thread.sleep! 
            //However, with the nature of the loading form it was hard to find anything there that I could wait on that wouldn't return a false positive
            Thread.Sleep(15);

            return new ResultsPage();
        }
    }
}
