Feature: Json Resource Item Parser
	In order to process a Json string
	As a service user 
	I want to be provided a list of all the parsed Resource item lists

Scenario: When a valid Json string is passed with 3 items, check count
	Given I have a new JsonResourceItemProcessor
	When I add Json objects for processing [{"ItemType":"File","Identifier":"File1","Location":"FileLocation1"},{"ItemType":"File","Identifier":"File1","Location":"FileLocation1"},{"ItemType":"File","Identifier":"File1","Location":"FileLocation1"}]
	Then the Json result should have a count of 3
	Then the Json result for type File should have a count of 3

Scenario: When a valid Json string is passed with 1 File and 2 Directory, check count
	Given I have a new JsonResourceItemProcessor
	When I add Json objects for processing [{"ItemType":"File","Identifier":"File1","Location":"FileLocation1"},{"ItemType":"Directory","Identifier":"File1","Location":"FileLocation1"},{"ItemType":"Directory","Identifier":"File1","Location":"FileLocation1"}]
	Then the Json result should have a count of 3
	Then the Json result for type File should have a count of 1
	Then the Json result for type Directory should have a count of 2