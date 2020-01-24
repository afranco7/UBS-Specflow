Feature: UBS Logins
	In order to ensure that some pages can be reached
	As a guess user
	I want to know if some login pages can be reached


Scenario Outline: Verify that UBS login pages are correctly reached
	Given I have navigated to UBS Logins page	
	When I select UBS Logins Button
	And I select on dropdown menu the login option <page>
	Then I should reach the expected <url>
Examples: 
| page  | url |
| UBS Safe | https://safe-ch2.ubs.com/app/H36/init?login& |
| UBS Connect | https://www.ubs.com/global/en/logins/connect.html |