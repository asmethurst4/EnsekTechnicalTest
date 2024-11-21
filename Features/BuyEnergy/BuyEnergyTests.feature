@TechnicalTest
Feature: Buy Energy Tests
Tests for the Buy Energy page

Background:
	Given the user is on the Buy Energy page

Scenario: User attempts to buy some Gas from the Buy Energy page
	When the user attempts to buy 52 units of Gas from the Buy Energy page
	Then the user will be taken to the Sale Confirmed page
		And the correct number of units of Gas being bought and remaining will be displayed

Scenario: User checks the Buy Energy table after buying some Gas
	Given the user has bought some Gas from the Buy Energy page
		And the user has been taken to the Sale Confirmed page
	When the user returns to the Buy Energy page
	Then the Buy Energy table will be updated to reflect the current amount of available Gas