Feature: Json Resource Item Parser
	In order to process a Json string
	As a service user 
	I want to be provided a list of all the parsed Resource item lists

Scenario: When a valid Json string is passed with 3 items, check count
	Given I have a new JsonResourceItemProcessor
	When I add string for Json processing "[{"ItemType":"File","Identifier":"File1","Location":"FileLocation1"},{"ItemType":"File","Identifier":"File1","Location":"FileLocation1"},{"ItemType":"File","Identifier":"File1","Location":"FileLocation1"}]"
	Then the Json result type should be Success
	Then the Json result should have a count of 3
	Then the Json result for type File should have a count of 3

Scenario: When a valid Json string is passed with 1 File and 2 Directory, check count
	Given I have a new JsonResourceItemProcessor
	When I add string for Json processing "[{"ItemType":"File","Identifier":"File1","Location":"FileLocation1"},{"ItemType":"Directory","Identifier":"File1","Location":"FileLocation1"},{"ItemType":"Directory","Identifier":"File1","Location":"FileLocation1"}]"
	Then the Json result type should be Success
	Then the Json result should have a count of 3
	Then the Json result for type File should have a count of 1
	Then the Json result for type Directory should have a count of 2

Scenario: When a valid Json string is passed with 1 File and 2 Directory including a \, check count
	Given I have a new JsonResourceItemProcessor
	When I add string for Json processing "[{"ItemType" : "File","Identifier" : "Templates","Location" : "D:\AppShare\DataSuite\Templates\UtilFunctions.xslt"}, {	"ItemType" : "Directory",	"Identifier" : "TemplateDirectory",		"Location" : "D:\AppShare\DataSuite\Templates"	}, 	{		"ItemType" : "WindowsService",		"Identifier" : "LevyWCF",		"Location" : "PPF.Levy.WCFHost"	}, 	{		"ItemType" : "Test",		"Identifier" : "TestInvalid",		"Location" : "PPF.Levy.WCFHost"	}]"
	Then the Json result type should be Success
	Then the Json result should have a count of 4
	Then the Json result for type File should have a count of 1
	Then the Json result for type Directory should have a count of 1
	Then the Json result for type WindowsService should have a count of 1
	Then the Json result for type Test should have a count of 1

Scenario: When an invalid Json string is passed expect an error
	Given I have a new JsonResourceItemProcessor
	When I add string for Json processing "sdfsdfsdf sdfs dfsd fsd fsdf sdfsdf"
	Then the Json result type should be Failure
