Feature: Search Jobs
	In order to avoid a bad behavior
	As a guess user
	I want to be sure that search jobs functionality is working as expected


Scenario: Verify that the search jobs Functionality
	Given I have navigated to UBS home page
	And I have selected search jobs on Careers dropdown
	When I select professionals link on Americas
	And I type the search <keyword> and <location>
	And I click search button
	Then I should see the <expectedResult>
Examples: 
| keyword  | location     | expectedResult |
| software | Barranquilla |  false  |
| software | Poland |  true  |
| software | China |  true  |
| software | Cartagena |  false  |
