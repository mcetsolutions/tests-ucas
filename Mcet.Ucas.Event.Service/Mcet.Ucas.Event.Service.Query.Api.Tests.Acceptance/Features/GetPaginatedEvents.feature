Feature: Get Paginated Events
	As an API consumer
	I want to retrieve events with pagination
	So that I can control the information retrieved

Background:
	Given a known set of test data exists

Scenario: Get events with default paging
	When I get all events
	Then the response status code is 200
	And the response page number is 1
	And the response page size is 10
	And the total number of events is 148
	And the total number of pages is 15
	And the number of page items is 10
	And the first page result is event with title 'Widget Corp'
	And the last page result is event with title 'C 4 Network Inc 'Shows that pop!''

Scenario: Get the 5th page of events
	When I get page 5 of events
	Then the response status code is 200
	And the response page number is 5 
	And the first page result is event with title 'Karolyn King Nelson > Nothing is fool proof to a sufficiently talented fool.'
	And the last page result is event with title 'Thrifty Oil Co'

Scenario: Get the last page of events with a custom page size
	Given a page size of 50
	When I get page 3 of events
	Then the response status code is 200
	And the response page number is 3 
	And the response page size is 50
	And the total number of pages is 3
	And the number of page items is 48