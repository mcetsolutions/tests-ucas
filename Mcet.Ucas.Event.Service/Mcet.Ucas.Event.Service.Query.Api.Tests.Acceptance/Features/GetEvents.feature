Feature: Get Events
	As an API consumer
	I want to retrieve events
	So that I can view information about events

Background:
	Given a known set of test data exists

Scenario: Get all events
	When I get all events
	Then the response status code is 200
	And the response includes events 'LuthorCorp for the investication, Plantation Restaurant, Goeman Wood Products Inc'

Scenario: Get a specific event
	When I get event 'a682adc7-1163-4a32-a867-3362756499f7'
	Then the response status code is 200
	And the response includes the event details
		| Field       | Value                                                  |
		| Id          | a682adc7-1163-4a32-a867-3362756499f7                   |
		| Title       | Dill Dill Carr & Stonbraker Pc                         |
		| Location    | Atlantis                                               |
		| StartDate   | 2014-06-10T09:00:00+01:00                              |
		| Organiser   |                                                        |
		| Category    | 1                                                      |
		| Description | Description for event 'Dill Dill Carr & Stonbraker Pc' |