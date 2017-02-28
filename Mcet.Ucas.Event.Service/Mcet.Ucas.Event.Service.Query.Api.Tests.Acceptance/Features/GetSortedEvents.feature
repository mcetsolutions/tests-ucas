Feature: Get Sorted Events
	As an API consumer
	I want to retrieve events in a specific order
	So that I can control the information retrieved

Background:
	Given a known set of test data exists

Scenario: Get events with default sort order
	When I get sorted events
	Then the response status code is 200
	And the results are ordered by descending StartDate

Scenario: Get events ordered by ascending Title
	Given a sort order of ascending Title
	When I get sorted events
	Then the response status code is 200
	And the results are ordered by ascending Title