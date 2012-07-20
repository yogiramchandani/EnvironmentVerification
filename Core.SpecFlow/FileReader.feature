Feature: Reading from File
	In order to read from a file
	As a system user
	I want to be told the validation errors if any exist

Scenario: Get Failure validation type for reading an invalid file
	When I create a new file reader with path ".\InvalidTestFile.txt"
	And I call validate file
	Then the validation result type should be "Failure"

Scenario: Get validation message for reading an invalid file
	When I create a new file reader with path ".\InvalidTestFile.txt"
	And I call validate file
	Then the validation result content should be "The file does not exist"

Scenario: Get Success validation type for reading a valid file
	When I create a new file reader with path "..\..\SampleFiles\ValidFile.txt"
	And I call validate file
	Then the validation result type should be "Success"

Scenario: Get validation message for reading a valid file
	When I create a new file reader with path "..\..\SampleFiles\ValidFile.txt"
	And I call validate file
	Then the validation result content should be "[{"ItemType":"File","Identifier":"File1","Location":"FileLocation1"}]"
