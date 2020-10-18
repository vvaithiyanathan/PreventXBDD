Feature: Registration 
	In order to use SH UK services
	As a Service User
	I want to register and start using the services

@registertag
Scenario: User Registration
	Given I am on the SH UK registration form
		And I enter a valid first name
		And I enter a valid Last name
		And I enter a valid Gender Identity
		And I enter a valid Assigned Sex
		And I enter a valid Partner Sex
		And I enter a valid Date Of Birth
		And I enter a valid Ethnicity
		And I enter a valid Address
		And I enter a valid Town
		And I enter a valid Postcode
		And I enter a valid County
		And I enter a valid Email address
		And I enter a valid Mobile Number
		And I enter a valid Contact Preference
		And I enter a valid Password
		And I enter a confirm Password which matches the password
		And I give consent to participate in research
		And I agree with the terms of use and privacy policy
	When I submit the registration form
	Then Redirects to account verification page

	Scenario: Registration fails unless the user provide an email address
	Given I am on the SH UK registration form
		And If the user did not enter an email address		
	When I submit the registration form
	Then I should see an error message 