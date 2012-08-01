Feature: Directory Verfication
	In order to verify if a directory exists in a system
	As a system user
	I want to be told if the directory exists

Scenario: For an existing directory, check the result message
	Given I have a new DirectoryVerifier
	When I add a directory path, identifier: Templates, path: D:\AppShare\DataSuite\Templates
	Then the directory verification result message should be Success connecting to Templates, Key: DirectoryPath, Value: D:\AppShare\DataSuite\Templates

Scenario: For an existing directory, check the result type
	Given I have a new DirectoryVerifier
	When I add a directory path, identifier: Templates, path: D:\AppShare\DataSuite\Templates
	Then the directory verification status should be Success

Scenario: For an existing directory, check the result count
	Given I have a new DirectoryVerifier
	When I add a directory path, identifier: Templates, path: D:\AppShare\DataSuite\Templates
	Then the directory verification count should be 1
	
Scenario: For a non existent directory, check the result message
	Given I have a new DirectoryVerifier
	When I add a directory path, identifier: Invalid, path: D:\AppShare\DataSuite\Invalid
	Then the directory verification result message should be Failure connecting to Invalid, Error Message: Directory not found, Key: DirectoryPath, Value: D:\AppShare\DataSuite\Invalid

Scenario: For a non existent directory, check the result type
	Given I have a new DirectoryVerifier
	When I add a directory path, identifier: Invalid, path: D:\AppShare\DataSuite\Invalid
	Then the directory verification status should be Failure

Scenario: For a non existent directory, check the result count
	Given I have a new DirectoryVerifier
	When I add a directory path, identifier: Invalid, path: D:\AppShare\DataSuite\Invalid
	Then the directory verification count should be 1

Scenario: 3 directory are added, check the result count
	Given I have a new DirectoryVerifier
	When I add a directory path, identifier: Templates, path: D:\AppShare\DataSuite\Templates
	When I add a directory path, identifier: Invalid, path: D:\AppShare\DataSuite\Invalid
	When I add a directory path, identifier: Invalid, path: D:\AppShare\DataSuite\Invalid
	Then the directory verification count should be 3

