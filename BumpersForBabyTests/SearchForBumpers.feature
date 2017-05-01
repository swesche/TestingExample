Feature: SearchForBumpers
	In order to keep my baby safe
	As a new parent
	I want to find a rubber baby buggy bumper on bing

@mytag
Scenario: Look for rubber baby buggy bumpers
	Given I have access to a web browser
	When I navigate to bing.com
	And I enter "Rubber Baby Buggy Bumper" in the search input box
	And I click the Search button
	Then I find results showing rubber baby buggy bumpers
