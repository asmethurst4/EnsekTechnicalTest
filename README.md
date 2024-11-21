ENSEK Technical Test

Notes
Firstly, apologies for this wall of text. I now am starting to wonder if the first two parts of the test were intended to be done manually, but I ended up automating them instead. I've provided the framework in a repo here (you should have an email invite to access it - if you can't access it, please let me know and I'll sort it): https://github.com/asmethurst4/EnsekTechnicalTest

My standard method of testing involves looking at the project involved and then breaking it down into different areas and writing down all the areas that need checking. I've done a pretty quick list below.

---------------------------------------------
Areas to test
---------------------------------------------
Header (all screens)
	Check all links go to the correct places

Home
	Check screen loads and all elements are displayed and spelled correctly with correct punctuation
	Click the Find Out More button
	Click the Buy Energy button
	Click the Sell Energy button
	Click the About Us button

About
	Check screen loads and all elements are displayed and spelled correctly with correct punctuation
	Check Find out more button goes to the correct place

Contact
	Check screen loads and all elements are displayed and spelled correctly with correct punctuation
	Cannot test further because it shows an error page

Register
	Check screen loads and all elements are displayed and spelled correctly with correct punctuation
	Attempt to register with different combinations of the following details
		No email/Invalid email/valid email/Invalid
		No password/invalid password/valid password
		No confirm password/invalid confirm password/valid confirm password
		Non-matching passwords

Log in
	Check screen loads and all elements are displayed and spelled correctly with correct punctuation
	Attempt to log in with different combinations of details
		No username/no password
		Username/no password
		No username/password
		Invalid username/invalid password
		Valid username/invalid password
		Valid username/valid password
	Click on Register as a new user link
	
Buy Gas
	Check screen loads and all elements are displayed and spelled correctly with correct punctuation
	Check that the time and date are correct
	Check that you can buy each of the available resources and the total 
	Check that buying consecutive amounts of an energy type returns the correct value each time
	Check that filling in multiple fields and clicking a specific buy button only purchases that energy type
	Check that filling in fields with invalid values (letters, special characters, negative amounts) doesn't allow the user to buy

Sell Gas
	Check screen loads and all elements are displayed and spelled correctly with correct punctuation
	Cannot test further because it doesn't load

---------------------------------------------
From there I'll start to explore and test things out, fleshing out each one with a test or multiple tests depending on the scenario. The ones I have automated are in the Features/BuyEnergy/BuyEnergyTests.feature and the Features/Home/HomeTests/HomeTests.feature files:

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

Scenario: User attempts to buy some Gas from the Buy Energy page
	When the user attempts to buy 52 units of Gas from the Buy Energy page
	Then the user will be taken to the Sale Confirmed page
		And the correct number of units of Gas being bought and remaining will be displayed

Scenario: User checks the Buy Energy table after buying some Gas
	Given the user has bought some Gas from the Buy Energy page
		And the user has been taken to the Sale Confirmed page
	When the user returns to the Buy Energy page
	Then the Buy Energy table will be updated to reflect the current amount of available Gas

Results (along with the API ones) are provided in the testresults.png screenshot in the root folder of the repository.

---------------------------------------------

As I was testing I made not of numerous bugs, most of which being text issues. These are as follows.

---------------------------------------------
Code
	Pretty much all elements missing IDs or names or anything sensible to identify them with leading to CSS selectors and XPaths being used.

Header
	Header bar allegedly has a collapse button in the elements that is either not visible or can't be clicked (on all pages but putting here)
	Ensek logo has a random hidden " next to it
	"Log in" should probably be "Log In" (not just the only instance of title and heading text being inconsistent - need to raise with people as to what the preferred way of capitalising titles is).

Home
	Probably shouldn't be abbreviating Corporation to Corp on the title
	Same for using an ! in "Doing all things energy since 2010!"

About
	Page URL is /Home/About instead of just /About
	Unnecessary second . in "About ENSEK Energy Corp.."
	Inconsistencies in the hyphens used in the sentences, namely "In 2010, we set out to solve a common problem in the energy industry that was costing suppliers – and ultimately customers - millions every year."
	Find out more link leads to a non-existent page

Contact
	Page URL is /Home/Contact instead of just /Contact
	Page throws up an error
	Error is spelled "Erorr" in the image

Buy Energy
	Discount notification says 30% off all gas but the image says 20%
	Discount notification length/height not in line with the energy buying length/height
	Can buy more than the available amount - no validation to prevent this
	Can buy negative amounts thus increasing the totals
	Can enter strings of letters and other characters into the fields which throws an error when clicking buy
	Can click buy with no value entered also throwing an error
	Buy button is either too tall for the fields or the other values in the rows should be centered vertically
	Excessive space at the bottom of the buying table under Oil - could be shortened

Sell Energy
	Page is under maintenance - not necessarily a bug but might want to be disabled with a notification from the home page
	
*Did not get around to checking Register or Log In screens

---------------------------------------------

If I was raising these properly for a developer to look at, they would be as follows:

---------------------------------------------

BUG: Discount notification says 30% off all gas but the image says 20%

Environment: QA
Browser: Chrome
Version: Latest
Severity: Medium

Repro Steps:
	1. Navigate to https://ensekautomationcandidatetest.azurewebsites.net
	2. Click on the "Buy energy >>" button
	3. Check the Special Discount section on the right of the screen (see Actual Outcome)
	
Actual Outcome
	Message says "Today we have a special discount of 30% off all Gas!" but the image below says "SAVE 20%".
	(Would provide an image of the screen for this section)
	
Expected Outcome
	Either message should say 20% or image should say 30%.
	
Notes
	It's not a major bug - i.e. it doesn't break anything but it should probably be fixed at some point.

---------------------------------------------

For the API tests, I also automated these through the same framework. I followed the same process as the UI in planning out testing.

PUT Buy energy
	Okay
	Bad request
	
GET Energy
	Okay

POST Login
	Okay
	Bad
	Unauthorised

DELETE Order
	Okay
	500 (bad ID)
	
PUT Order
	Okay
	500 (bad ID)

GET Orders
	Okay
	500 (bad ID)

POST Reset
	Okay
	Unauthorised

---------------------------------------------
The required API tests are as follows and are in the Features/Api/TestTests.feature file:

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

In addition to the tests that were required, I automated the three Login tests as follows and are in the Features/Api/TestTests.feature file:

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


---------------------------------------------
Bugs found
There is an issue with the test in that because Nuclear power is unavailable to buy, you cannot buy any of it, so my test fails with that order. However I did add another test that excludes buying the Nuclear power.

Other bugs I found were the ability to add orders with duplicate ID in the API. This means you can only return the most recent one with that ID.

When buying a quantity of fuel the API response details the purchased and remaining the wrong way around. The right quantities are purchased though and the cost calculation is correct too.

Also, when retrieving the orders there doesn't seem to be any ordering to them. Not a bug as such but would be a nice to have feature.
