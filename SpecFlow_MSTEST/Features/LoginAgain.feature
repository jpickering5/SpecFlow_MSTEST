Feature: LoginAgain
	To test login functionality of application

@login
Scenario Outline: Test login functionality of application again
	Given I navigate to the application with the following browsers
		| Browsers   |
		| <Browsers> |
	And I click the login link
	And I enter username and password
		| UserName | Password |
		| admin    | password |
	And I click login
	#Then I should see the user logged in to the application

	Examples: 
	| Browsers |
	| chrome   |
	| firefox  |
		
	