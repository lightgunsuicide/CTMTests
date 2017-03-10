README
These tests seek to cover, as much as is possible in three scenarios, the happy paths (so no negative tests) through the energy user journey of CTM. 


**SETUP
These tests were written in Visual Studio 2015 Community and use the following nuget packages (in both projects): 
Specflow, Selenium webdriver, Firefox webdriver, webdriver support 

Hopefully a nuget restore will add any references missing however it has been known for these packages to need adding to similar projects when they have been 

During development the tests have been run through resharpers Unit Test Sessions window, although this should not be a requirement to run the tests.

These tests have been run numerous times with 100% pass rate and are stable on the configuration they were developed on. 


**STRUCTURE:
The solution is divded into two projects, Framework and Tests. Framework includes directories for abstract and concrete page classes for page objects and a separate WebExtensions folder for explicit wait functionality. Tests contains a feature file with the three scenarios, the steps file in another directory and a WebDriverSupport class which contains all specflow parameter methods (BeforeScenario, AfterScenario) and sets up the context injection for the tests. The Tests project also contains a Models directory, including the IUser interface and three models. This made it possible to cover more varied tests by varying each users preferences without over-loading the specflow scenarios - special effort has been made to keep the gherkin at business-relatable level.


The tests:
On approach: Allowing that exhaustive test coverage would be close to impossible in three scenarios and undesirable in a CI environment where these tests run frequently, effort has been made to acheive considerable cover within the parameters of the task set.

It was decided to split the tests by gas, electricty and the combined gas and electrical journey as these seem to be the journeys wit the most distinctions between them, therefore providing natural groupings. 

Note effort has been made to make sure these test cases go through as many options as possible through each path, ALTHOUGH they only go through each path once
in a specific way. For example, the gas prices test checks all suppliers, leaving a blind spot on all suppliers and electricity. 
It would be recommended to carry out exploratory, manual testing or add more scenarios to this feature in the event of the energy user journey being updated


This is not an exhaustive list of suppliers and their tarriffs - to include the whole list would take an extrodinary amount of time. These tests need to run frequently as part of CI.
Howwever, it may prove beneficial to create a truly exhaustive version of this table as a regression test to be run in place of manual testing, outside of the CI process


