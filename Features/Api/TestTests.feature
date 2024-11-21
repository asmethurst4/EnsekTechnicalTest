Feature: Test Tests
The actual tests I'm required to do for the assessment

Background: 
	Given the user has logged in and received a valid authorisation token

Scenario: User resets the test data
	When the user sends a Reset request with a valid authorisation token
	Then the system will return a 200 Success response for the Reset request
		And only the default Energy supply data will be present
		And only the default Order data will be present

Scenario: User buys a quantity of each fuel and confirms the number of orders created before the current date
	Given the user has reset the test data
	When the user successfully buys 40 units of Electric
		And the user successfully buys 30 units of Gas
		And the user successfully buys 20 units of Nuclear
		And the user successfully buys 10 units of Oil
	Then the Orders list will display all the newly created orders
		And there will be 5 orders created before the current date

Scenario: User buys a quantity of each fuel except nuclear and confirms the number of orders created before the current date
	Given the user has reset the test data
	When the user successfully buys 40 units of Electric
		And the user successfully buys 30 units of Gas
		And the user successfully buys 10 units of Oil
	Then the Orders list will display all the newly created orders
		And there will be 5 orders created before the current date