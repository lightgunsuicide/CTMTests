Feature: CTM energy user journey
As a user of the CTM website
I want to compare prices of enegy suppliers
So that I can choose the best deal on my energy 

Background: 
Given I have navigated to the energy supplier page of CTM 

@gasUserJourney
Scenario Outline: User wants to compare gas prices with a range of suppliers
	When I enter my supplier details as a user who wants to compare gas prices
	And I choose my supplier as <supplier>
	And I click Next
	And I enter my gas energy details including my '<gasTariff>' and '<howIPay>'
	And I select my preferences for a gas user 
	Then I click Go To Prices 
	And I see the lowest price output 

	Examples: 
	| supplier       | gasTariff                         | howIPay                |
	| British Gas    | Fix & Fall March 2016             | Monthly Direct Debit   |
	| EDF Energy     | Blue+Fixed Prepay February 2018   | Prepayment Meter       |
	| E.ON           | EnergyPlan Paper Billing          | Quarterly Direct Debit |
	| npower         | Feel Good Fix May 2019            | Pay On Receipt Of Bill |
	| Scottish Power | Standard                          | Standing Order         |
	| SSE            | SSE 1 Year Fixed v4 Paper Billing | Pay On Receipt Of Bill |

	@electricUserJourney
Scenario Outline: User wants to compare electricity prices with a range of tariffs and payment plans (for existing payment)
 	When I enter my supplier details as a user who wants to compare electricity prices
	And I choose my supplier as <supplier>
	And I click Next
	And I enter electricty energy details including my '<electricityTariff>' and '<howIPay>' 
	And I select my preferences for an electricity user 
	Then I click Go To Prices 
	And I see the lowest price output 

	Examples: 
	| supplier       | electricityTariff                 | howIPay                |
	| British Gas    | Standard                          | Monthly Direct Debit   |
	| EDF Energy     | Standard (Variable)               | Pay On Receipt Of Bill |
	| E.ON           | Fixed 1 Year                      | Monthly Direct Debit   |
	| npower         | Standard                          | Prepayment Meter       |
	| Scottish Power | Standard                          | Weekly                 |
	| SSE            | SSE 1 Year Fixed v4 Paper Billing | Pay On Receipt Of Bill |

	@bothUserJourney 
Scenario Outline: User wants to compare both gas and electricity prices for their future preferred payment arrangement
	When I enter my supplier details as a user who wants to compare both gas and electricity prices
	And I select '<otherSupplier>' as my supplier
	And I click Next
   And I enter my energy details
	And I select my preferences for my '<preferredTariff>' and '<preferredPaymentType>'
	Then I click Go To Prices 
	And I see the lowest price output

	Examples: 
	| isOrIsNotSameSupplier | otherSupplier      | preferredTariff | preferredPaymentType   |
	| Yes                   | Affect Energy      | Fixed tariff    | Monthly Direct Debit   |
	| No                    | Sainsbury's Energy | Variable tariff | Quarterly direct debit |
	| Yes                   | Affect Energy      | All tariffs     | All payment types      |
	| No                    | Sainsbury's Energy | Fixed tariff    | Pay On Receipt Of Bill |