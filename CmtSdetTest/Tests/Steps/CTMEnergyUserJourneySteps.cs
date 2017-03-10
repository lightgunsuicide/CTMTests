using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using CmtSdetTest.Concrete;
using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Models;
using Tests;

namespace Tests.Steps
{
    [Binding]
    public class CTMEnergyUserJourneySteps
    {
        private IUser _user;
        private SupplierPage _supplierPage;
        private EnergyPage _energyPage;
        private PreferencesPage _preferencesPage;
        private ResultsPage _resultsPage; 

        [Given(@"I have navigated to the energy supplier page of CTM")]
        public void GivenIHaveNavigatedToTheEnergySupplierPageOfCTM()
        {
             _supplierPage = new WebDriverSupport().OpenCTMEnergyJourney();
            _user = ScenarioContext.Current.Get<IUser>("User");
        }

        [When(@"I enter my supplier details as a user who wants to compare electricity prices")]
        public void WhenIEnterMySupplierDetailsAsAUserWhoWantsToCompareElectricPrices()
        {
            _supplierPage.EnterPostCode(_user.defaultPostcode);
            _supplierPage.ClickFindPostcode();         
            _supplierPage.ClickCompareElectric();
          
            if (_user.hasBill)
            {
                _supplierPage.ClickHasBill();
            }
            else
            {
                _supplierPage.ClickHasNoBill();
            }   
        }


        [When(@"I enter my supplier details as a user who wants to compare gas prices")]
        public void WhenIEnterMySupplierDetailsAsAUserWhoWantsToCompareGasPrices()
        {
            _supplierPage.EnterPostCode(_user.defaultPostcode);
            _supplierPage.ClickFindPostcode();
            _supplierPage.ClickCompareGas();

            if (_user.hasBill)
            {
                _supplierPage.ClickHasBill();
            }
            else
            {
                _supplierPage.ClickHasNoBill();
            }  
        }

        [When(@"I choose my supplier as (.*)")]
        public void WhenIChooseMySupplierAs(string supplier)
        {
            _user.supplier = supplier;

            var userType = _user.GetType();

            switch (userType.ToString())
            {
                case "Tests.Models.ElectricUser":
                    _supplierPage.ClickElectricSupplier(supplier);
                    break;

                case "Tests.Models.GasUser":
                    _supplierPage.ClickSupplier(supplier);
                    break;
            } 
        }
        
        [When(@"I click Next")]
        public void WhenIClickNext()
        {
            _energyPage = _supplierPage.ClickNext();
        }

        [When(@"I enter my gas energy details including my '(.*)' and '(.*)'")]
        public void WhenIEnterMyGasEnergyDetailsIncludingMyAnd(string gasTariff, string howIPay)
        {
            _energyPage.SelectGasTariff(gasTariff);
            _energyPage.SelectHowYouPayForGas(howIPay);

            if (_user.isGasMainSourceOfHeating)
            {
                _energyPage.ClickGasIsMainSourceOfHeating();
            }
            else
            {
                _energyPage.ClickGasIsNotMainSourceOfHeating();
            }

            if(_user.measureGasUseIn == "kWh")
            {
                _energyPage.ClickGasUsageInkWh();
            }
            else
            {
                _energyPage.ClickGasUsageInPound();
            }

            _energyPage.EnterGasUsageValue(_user.gasUsesageValue.ToString());
            _energyPage.SelectGasUsageInterval(_user.gasUseageIncrement);
            _energyPage.ClickGasBillDateBox();
            _energyPage.PickGasBillDateFromTable();
            _preferencesPage = _energyPage.ClickNext();
        }

       
        [When(@"I select my preferences for a gas user")]
        public void WhenISelectMyPreferencesForAGasUser()
        {
            _preferencesPage.ClickFixedRate();
            if (!_user.supplier.Equals("EDF Energy"))
            {
                _preferencesPage.ClickAllPayments();
            }
              
           _preferencesPage.EnterEmailAddress(_user.emailAddress);
        }

        [When(@"I select my preferences for an electricity user")]
        public void WhenISelectMyPreferencesForAnElectricUser()
        {
            _preferencesPage.ClickVariableRate();
            if (_user.paymentMethod != "Prepayment Meter")
            {
                _preferencesPage.ClickMonthlyPayment();
            }

            _preferencesPage.EnterEmailAddress(_user.emailAddress);
        }

        [When(@"I enter electricty energy details including my '(.*)' and '(.*)'")]
        public void WhenIEnterElectrictyEnergyDetailsIncludingMyAnd(string electricityTariff, string howIPay)
        {
            _user.paymentMethod = howIPay;

            _energyPage.SelectEletricTariff(electricityTariff);
            if (_user.hasEconomy7Meter)
            {
                _energyPage.ClickEconomy7MeterYes();
            }
            else
            {
                _energyPage.ClickEconomy7MeterNo();
            }
           
            _energyPage.SelectHowYouPayForElectric(howIPay);

            if (_user.isElecticMainSourceOfHeating)
            {
                _energyPage.ClickElectricIsMainSourceOfHeating();
            }
            else
            {
                _energyPage.ClickElectricIsNotMainSourceOfHeating();
            }

            if (_user.measureElectricalUseIn == "kWh")
            {
                _energyPage.ClickUsageInkWh();
            }
            else
            {
                _energyPage.ClickUsageInPound();
            }

            _energyPage.EnterElecticUsageValue(_user.electricalUsesageValue.ToString());
            _energyPage.SelectElectricalUsageInterval(_user.electricalUseageIncrement);
            _energyPage.ClickElectricBillDateBox();
            _energyPage.PickElectricBillDateFromTable();
            _preferencesPage = _energyPage.ClickNext();
        }
        
        [When(@"I enter my supplier details as a user who wants to compare both gas and electricity prices")]
        public void WhenIEnterMySupplierDetailsAsAUserWhoWantsToCompareBothGasAndElectricityPrices()
        {
            _supplierPage.EnterPostCode(_user.defaultPostcode);
            _supplierPage.ClickFindPostcode();
            _supplierPage.ClickCompareGas();

            if (_user.hasBill)
            {
                _supplierPage.ClickHasBill();
            }
            else
            {
                _supplierPage.ClickHasNoBill();
            }
            _supplierPage.ClickCompareBoth();
            
        
        }
        
        [When(@"I select if my energy ""(.*)""")]
        public void WhenISelectIfMyEnergy(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select '(.*)' as my supplier")]
        [When(@"I select ""(.*)"" as my supplier")]
        public void WhenISelectAsMySupplier(string otherSupplier)
        {
            _supplierPage.SelectOtherSupplier(otherSupplier);
        }
        
        [When(@"I enter my energy details")]
        public void WhenIEnterMyEnergyDetails()
        {
            _energyPage.enterCombinedUsages(_user.electricalUsesageValue.ToString(), _user.gasUsesageValue.ToString());
            _preferencesPage = _energyPage.ClickNext();
        }


        [When(@"I select my preferences for my '(.*)' and '(.*)'")]
        [When(@"I select my preferences for my ""(.*)"" and ""(.*)""")]
        public void WhenISelectMyPreferencesForMyAnd(string preferredTariff, string preferredPaymentType)
        {
            switch (preferredTariff)
            {
                case "Fixed tariff":
                    _preferencesPage.ClickFixedRate();
                    break;

                case "Variable tariff":
                    _preferencesPage.ClickVariableRate();
                    break;

                case "All tariffs":
                    _preferencesPage.ClickAllRates();
                    break;
            }

            switch (preferredPaymentType)
            {
                case "Monthly Direct Debit":
                    _preferencesPage.ClickMonthlyPayment();
                    break;
                case "Quarterly direct debit":
                    _preferencesPage.ClickQuarterlyPayment();
                    break;

                case "All payment types":
                    _preferencesPage.ClickAllPayments();
                    break;

                case "Pay On Receipt Of Bill":
                    _preferencesPage.ClickBillsOnReceipt();
                    break;
            }
            _preferencesPage.EnterEmailAddress(_user.emailAddress);
        }
        
        [Then(@"I click Go To Prices")]
        public void ThenIClickGoToPrices()
        {
          _preferencesPage.ClickHaveReadTermsAndConditions();
          _resultsPage = _preferencesPage.ClickNext();
        }
        
        [Then(@"I see the lowest price output")]
        public void ThenISeeTheLowestPriceOutput()
        {
            //There are so many possible things to assert on this page it was hard to know 
            //what to go with and what the business rules were, so kept it as simple as possible
            var resultsPageUrl = _resultsPage.GetCurrentUrl();
            Assert.AreEqual(resultsPageUrl, "https://energy.comparethemarket.com/energy/v2/yourResults?AFFCLIE=TSTT");
        }
    }
}
