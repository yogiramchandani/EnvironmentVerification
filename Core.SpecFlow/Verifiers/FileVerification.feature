Feature: File Verfication
	In order to verify if a File exists in a system
	As a system user
	I want to be told if the File exists

Scenario: For an existing File, check the result message
	Given I have a new FileVerifier
	When I add a File path, identifier: Templates, path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt
	Then the File verification result message should be Success verifying Templates, Key: FilePath, Value: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt

Scenario: For an existing File, check the result type
	Given I have a new FileVerifier
	When I add a File path, identifier: Templates, path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt
	Then the File verification status should be Success

Scenario: For an existing File, check the result count
	Given I have a new FileVerifier
	When I add a File path, identifier: Templates, path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt
	Then the File verification count should be 1
	
Scenario: For a non existent File, check the result message
	Given I have a new FileVerifier
	When I add a File path, identifier: Invalid, path: D:\AppShare\DataSuite\Invalid\UtilFunctions.xslt
	Then the File verification result message should be Failure verifying Invalid, Error Message: File not found, Key: FilePath, Value: D:\AppShare\DataSuite\Invalid\UtilFunctions.xslt

Scenario: For a non existent File, check the result type
	Given I have a new FileVerifier
	When I add a File path, identifier: Invalid, path: D:\AppShare\DataSuite\Invalid\UtilFunctions.xslt
	Then the File verification status should be Failure

Scenario: For a non existent File, check the result count
	Given I have a new FileVerifier
	When I add a File path, identifier: Invalid, path: D:\AppShare\DataSuite\Invalid\UtilFunctions.xslt
	Then the File verification count should be 1

Scenario: 3 File are added, check the result count
	Given I have a new FileVerifier
	When I add a File path, identifier: Templates, path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt
	When I add a File path, identifier: Invalid, path: D:\AppShare\DataSuite\Invalid\UtilFunctions.xslt
	When I add a File path, identifier: Invalid, path: D:\AppShare\DataSuite\Invalid\UtilFunctions.xslt
	Then the File verification count should be 3
