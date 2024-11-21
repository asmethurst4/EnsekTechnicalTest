Feature: Login Tests
Login tests for the test API

Scenario: User attempts to log in with a valid username and password
	When the user submits an authorised login request with the following details
		| Username | Password |
		| test     | testing  |
	Then the system returns a 200 Success response and an access token

Scenario: User attempts to log in with no username and password
	When the user submits a bad login request with the following details
	Then the system returns a 400 Bad Request response and no access token

Scenario: User attempts to log in with an invalid username and password
	When the user submits an unauthorised login request with the following details
		| Username | Password |
		| not      | valid    |
	Then the system returns a 401 Unauthorised response and no access token