@TechnicalTest
Feature: Home Tests
Tests for checking the Home page

Scenario: User checks the Home page is displayed
	When the user is on the Home page
	Then the user will see the header displayed properly
		And the user will see the Home page title section displayed properly
		And the user will see the Home page Buy some energy section displayed properly
		And the user will see the Home page Sell some energy section displayed properly
		And the user will see the Home page About us section displayed properly
		And the user will see the footer displayed properly

Scenario: User clicks on the Home page Buy energy button
	Given the user is on the Home page
	When the user clicks the Buy energy button
	Then the user is taken to the Buy energy page
