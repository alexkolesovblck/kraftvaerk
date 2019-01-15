Feature: Feature
	I read several test scenario,
	And I want the automatic tests to run them.

@tag
Scenario Outline: VerifyCorrectLinkOnTheWebsite
	Given I open browser and navigate to <search> page
	Then I send keys to search form with the text like <website>
	And verify that first result on the page has a correct link

	Examples: 
	| search | website |
	| google | yandex  |