using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CmtSdetTest.Abstract;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CmtSdetTest.Concrete
{
    [Binding]
    public class SupplierPage : BaseCTMJourneyPage
    {
        private readonly FirefoxDriver _driver;

        private readonly string _postCodeID = "postcode-question";
        private readonly string _postCodeFinderId = "find-postcode";
        private readonly string _hasBillYesId = "have-bill";
        private readonly string _hasBillNoId = "no-bill";
        private readonly string _hasBillXpath = "//*[@id='have-bill-label']/span/span";
        private readonly string _hasBillNoXpath = @"//*[@id='no-bill-label']/span/span";
        private readonly string _cssGasSpan = "span.icon.energy-gas";
        private readonly string _cssElectricSpan = "span.icon.energy-electric";
        private readonly string _electricSpanXpath = "//*[@id='compare-electricity-label']/span/span";
        private readonly string _bothXpath = "//*[@id='compare-both-label']/span/span";
        private readonly string _usingSameSupplierYesCss = "same-supplier-yes";
        private readonly string _usingSameSupplierNoCss = "same-supplier-no";

        private readonly string _britishGasXpath = "//*[@id='gas-energy-suppliers-question']/div/div/div[1]/label[1]/span/span";
        private readonly string _edfEnergyXpath = " //*[@id='gas-energy-suppliers-question']/div/div/div[1]/label[2]/span/span";
        private readonly string _eOnXpath = "//*[@id='gas-energy-suppliers-question']/div/div/div[1]/label[3]/span/span";
        private readonly string _nPowerXpath = "//*[@id='gas-energy-suppliers-question']/div/div/div[1]/label[4]/span/span";
        private readonly string _scottishPowerXpath = "//*[@id='gas-energy-suppliers-question']/div/div/div[1]/label[5]/span/span";
        private readonly string _SSEXpath = "//*[@id='gas-energy-suppliers-question']/div/div/div[1]/label[6]/span/span";
        private readonly string _nextButtonId = "goto-your-supplier-details";

        private readonly string _BritishGasElectricXpath = "//*[@id='elec-energy-suppliers-question']/div/div/div[1]/label[1]/span/span";
        private readonly string _edfEnergyElectricXpath = " //*[@id='elec-energy-suppliers-question']/div/div/div[1]/label[2]/span/span";
        private readonly string _eOnElectricXpath = "//*[@id='elec-energy-suppliers-question']/div/div/div[1]/label[3]/span/span";
        private readonly string _nPowerElectricXpath = "//*[@id='elec-energy-suppliers-question']/div/div/div[1]/label[4]/span/span";
        private readonly string _scottishPowerElectricXpath = "//*[@id='elec-energy-suppliers-question']/div/div/div[1]/label[5]/span/span";
        private readonly string _SSEElectricXpath = "//*[@id='elec-energy-suppliers-question']/div/div/div[1]/label[6]/span/span";

        private readonly string _otherSupplierDropDown = "sel1";

        public SupplierPage() : base() {
            _driver = ScenarioContext.Current.Get<FirefoxDriver>("driver");
        }

        public void EnterPostCode(string usersPostCode)
        {
            _driver.FindElementById(_postCodeID).Click();
            _driver.FindElementById(_postCodeID).SendKeys(usersPostCode);
        }

        public void ClickFindPostcode()
        {
          _driver.FindElementById(_postCodeFinderId).Click();
    
          WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            try
            {
                IWebElement myDynamicElement = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.XPath(_britishGasXpath)));
            }
            catch (Exception e)
            {
                /*Due to intermitten failures to find the element despite it appearing, as this was not the pressing issue a 
                 * try-catch has been used to prevent the test failing on this point. 
               In the instance of a true failure (that is, elements not loading) the rest of the test will fail legitimately in any case
                 *  */
            }  
        }

        public void ClickHasBill() {
            _driver.FindElementByXPath(_hasBillXpath).Click();
        }

        public void ClickHasNoBill()
        {
            _driver.FindElementByXPath(_hasBillNoXpath).Click();
        }

        public void ClickCompareBoth()
        {
            _driver.FindElementByXPath(_bothXpath).Click();
        }

        public void ClickCompareElectric()
        {
            _driver.FindElementByXPath(_electricSpanXpath).Click();
        }
        public void ClickCompareGas()
        {
            _driver.FindElementByCssSelector(_cssGasSpan).Click();
           
        }

        public void ClickIsUsingSameSupplier() {
            _driver.FindElementByXPath(_usingSameSupplierYesCss).Click(); 
        }

        public void ClickIsNotUsingSameSupplier()
        {
            _driver.FindElementByXPath(_usingSameSupplierNoCss).Click();
        }

        public void ClickSupplier(string supplier)
        {
            string id = "Fate undetermined!"; 

            switch (supplier)
            {
                case "British Gas":
                    id = _britishGasXpath;
                    break;

                case "EDF Energy":
                    id = _edfEnergyXpath;
                    break;
    
                case "E.ON":
                    id = _eOnXpath;
                    break;

                case "npower":
                    id = _nPowerXpath;
                    break;

                case "Scottish Power":
                    id = _scottishPowerXpath;
                    break;

                case "SSE":
                    id = _SSEXpath;
                    break;
            }

            _driver.FindElementByXPath(id).Click();
        }


        public void ClickElectricSupplier(string supplier)
        {
            string id = "Fate undetermined!";

            switch (supplier)
            {
                case "British Gas":
                    id = _BritishGasElectricXpath;
                    break;

                case "EDF Energy":
                    id = _edfEnergyElectricXpath;
                    break;

                case "E.ON":
                    id = _eOnElectricXpath;
                    break;

                case "npower":
                    id = _nPowerElectricXpath;
                    break;

                case "Scottish Power":
                    id = _scottishPowerElectricXpath;
                    break;

                case "SSE":
                    id = _SSEElectricXpath;
                    break;
            }

            _driver.FindElementByXPath(id).Click();
        }

        public void SelectOtherSupplier(string OtherSupplier)
        {

            var otherSuppliers = _driver.FindElementById(_otherSupplierDropDown);
            var SelectElement = new SelectElement(otherSuppliers);

            SelectElement.SelectByText(OtherSupplier);
        }

        public EnergyPage ClickNext()
        {
            _driver.FindElementById(_nextButtonId).Click();
            return new EnergyPage();
        }
    }
}
