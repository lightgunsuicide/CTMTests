using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CmtSdetTest.Abstract;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CmtSdetTest.Concrete
{
    public class EnergyPage : BaseCTMJourneyPage
    {
        private readonly FirefoxDriver _driver;

        #region Electric Ids
        private readonly string _electrcityTariffId = "electricity-tariff-additional-info";
        private readonly string _economy7MeterYesXpath = "//*[@id='economy-7-question']/div/div/label[1]/span";
        private readonly string _noEconomy7MeterNoXpath = "//*[@id='economy-7-question']/div/div/label[2]/span";
        private readonly string _howDoYouPayForElectricId = "electricity-payment-method-dropdown-link";
        private readonly string _isElectricMainHeatSourceYesXpath = "//*[@id='electricity-main-heating-source-question']/div/div/label[1]/span";
        private readonly string _isElectricMainHeatSourceNoXpath = "//*[@id='electricity-main-heating-source-question']/div/div/label[2]/span";
        private readonly string _usageIsInKWhXpath = "//*[@id='electricity-usage-question']/div/div/div[1]/label[1]/span";
        private readonly string _usageIsInPoundXpath = "//*[@id='electricity-usage-question']/div/div/div[1]/label[2]/span";
        private readonly string _electricUseId = "electricity-usage";
        private readonly string _electricUseValueId = "electricity-spend";
     
        private readonly string _electricUseDropDownId = "electricity-spend-dropdown";
        private readonly string _electricBillDateXpath = "//*[@id='electricity-bill-day']";
        private readonly string _electricBillDate = "//*[@id='electricity-bill-day_table']/tbody/tr[2]/td[6]/div";

        #endregion

        #region Gas Ids
        private readonly string _gasTariffId = "gas-tariff-additional-info";
        private readonly string _howDoYouPayForGasId = "gas-payment-method-dropdown-link";
        private readonly string _isGasMainHeatSourceYesXpath = "//*[@id='gas-main-heating-source-question']/div/div/label[1]/span";
        private readonly string _isGasMainHeatSourceNoXpath = "//*[@id='gas-main-heating-source-question']/div/div/label[2]/span";
        private readonly string _gasUsageIsInKWhXpath = "//*[@id='gas-type-of-bill-question']/div/div/div[1]/label[1]/span";
        private readonly string _gasUsageIsInPoundXpath = "//*[@id='gas-type-of-bill-question']/div/div/div[1]/label[2]/span";
        private readonly string _gasUseId = "gas-usage";
        private readonly string _gasUseDropDownId = "type-of-Gas-bill-usage-dropdown";
        private readonly string _gasBillDateId = "gas-bill-day";
        private readonly string _gasBillDate =  "//*[@id='gas-bill-day_table']/tbody/tr[1]/td[5]/div";
        #endregion

        //For combined page
        private readonly string _gasCurrentSpendValueId = "gas-current-spend";
        private readonly string _electricCurrentUseValueId = "electricity-current-spend";

        private readonly string _goToYourEnergyId = "goto-your-energy";

        public EnergyPage() : base()
        {
            _driver = ScenarioContext.Current.Get<FirefoxDriver>("driver");
        }

        #region Electric functionality
        public void SelectEletricTariff(string tariff) {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            try
            {
                IWebElement myDynamicElement = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.XPath(_electricBillDateXpath)));
            }
            catch (Exception e) { }

            var tariffList = _driver.FindElementById(_electrcityTariffId);
            var selectElement = new SelectElement(tariffList);

            selectElement.SelectByText(tariff);
        }

        public void ClickEconomy7MeterYes() {
            _driver.FindElementByXPath(_economy7MeterYesXpath).Click();
        }

        public void ClickEconomy7MeterNo()
        {
            _driver.FindElementByXPath(_noEconomy7MeterNoXpath).Click();
        }

        public void SelectHowYouPayForElectric(string paymentMethod) {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            try
            {
                IWebElement myDynamicElement = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id(_howDoYouPayForElectricId)));
            }
            catch (Exception e) { }

            var payMethods = _driver.FindElementById(_howDoYouPayForElectricId);
            var SelectElement = new SelectElement(payMethods);

            SelectElement.SelectByText(paymentMethod);
        }

        public void ClickElectricIsMainSourceOfHeating() {
            _driver.FindElementByXPath(_isElectricMainHeatSourceYesXpath).Click();         
        }
        public void ClickElectricIsNotMainSourceOfHeating()
        {
            _driver.FindElementByXPath(_isElectricMainHeatSourceNoXpath).Click();
        }
        
        public void ClickUsageInkWh()
        {
            _driver.FindElementByXPath(_usageIsInKWhXpath).Click();
        }

        public void ClickUsageInPound()
        {
            _driver.FindElementByXPath(_usageIsInPoundXpath).Click();
        }

        public void EnterElecticUsageValue(string usage) {

            _driver.FindElementById(_electricUseValueId).Click();
            _driver.FindElementById(_electricUseValueId).Clear();
            _driver.FindElementById(_electricUseValueId).SendKeys(usage);         
        }

        public void enterCombinedUsages(string electricUse, string gasUse)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            try
            {
                IWebElement myDynamicElement = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id(_electricCurrentUseValueId)));
            }
            catch (Exception e) { }

            _driver.FindElementById(_electricCurrentUseValueId).Click();
            _driver.FindElementById(_electricCurrentUseValueId).Clear();
            _driver.FindElementById(_electricCurrentUseValueId).SendKeys(electricUse);

            _driver.FindElementById(_gasCurrentSpendValueId).Click();
            _driver.FindElementById(_gasCurrentSpendValueId).Clear();
            _driver.FindElementById(_gasCurrentSpendValueId).SendKeys(electricUse);
        }

        public void SelectElectricalUsageInterval(string interval)
        {
            var intervals = _driver.FindElementById(_electricUseDropDownId);
            var SelectElement = new SelectElement(intervals);

            SelectElement.SelectByText(interval);
        }

        public void ClickElectricBillDateBox()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            try
            {
                IWebElement myDynamicElement = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.XPath(_electricBillDateXpath)));
            }
            catch (Exception e) {}

            _driver.FindElementByXPath(_electricBillDateXpath).Click();
        }

        public void PickElectricBillDateFromTable()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            try
            {
                IWebElement myDynamicElement = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.XPath(_electricBillDate)));
            }
            catch (Exception e) { }

            _driver.FindElementByXPath(_electricBillDate).Click();
        }

        public PreferencesPage ClickNext()
        {
            _driver.FindElementById(_goToYourEnergyId).Click();           
            return new PreferencesPage();
        }

        #endregion

        #region Gas functionality
        public void SelectGasTariff(string tariff)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            try
            {
                IWebElement myDynamicElement = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id(_gasTariffId)));
            }
            catch (Exception e)
            {
              
            }

            var tariffList = _driver.FindElementById(_gasTariffId);
            var selectElement = new SelectElement(tariffList);

            selectElement.SelectByText(tariff);
        }

        public void SelectHowYouPayForGas(string paymentMethod)
        {
            var payMethods = _driver.FindElementById(_howDoYouPayForGasId);
            var SelectElement = new SelectElement(payMethods);

            SelectElement.SelectByText(paymentMethod);
        }

        public void ClickGasIsMainSourceOfHeating()
        {
            _driver.FindElementByXPath(_isGasMainHeatSourceYesXpath).Click();
        }
        public void ClickGasIsNotMainSourceOfHeating()
        {
            _driver.FindElementByXPath(_isGasMainHeatSourceNoXpath).Click();
        }

        public void ClickGasUsageInkWh()
        {
            _driver.FindElementByXPath(_gasUsageIsInKWhXpath).Click();
        }

        public void ClickGasUsageInPound()
        {
            _driver.FindElementByXPath(_gasUsageIsInPoundXpath).Click();
        }

        public void EnterGasUsageValue(string usage)
        {
            _driver.FindElementById(_gasUseId).SendKeys(usage);
        }

        public void SelectGasUsageInterval(string interval)
        {
            var intervals = _driver.FindElementById(_gasUseDropDownId);
            var SelectElement = new SelectElement(intervals);

            SelectElement.SelectByText(interval);
        }

        public void ClickGasBillDateBox()
        {
          _driver.FindElementById(_gasBillDateId).Click();  
        }

        public void PickGasBillDateFromTable()
        {
           _driver.FindElementByXPath(_gasBillDate).Click();  
        }

        #endregion
    }
}