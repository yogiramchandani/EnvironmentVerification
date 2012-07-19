Feature: Environment Verification Processor
	In order to process a batch of environment artifacts
	As a service user 
	I want to be told the status of all the artifacts

Scenario: When 3 items are passed, check for count
	Given I have a new EnvironmentVerificationProcessor
	When I add items for processing
	| type      | name              | location                                           |
	| File      | Template          | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| Directory | TemplateDirectory | D:\AppShare\DataSuite\Templates                    |
	| Invalid   | InvalidName       |		Test										 |
	Then the Environment Verification Processor result count should be 3

Scenario: When 2 Valid and 1 invalid items are passed, check return value
	Given I have a new EnvironmentVerificationProcessor
	When I add items for processing
	| type      | name              | location                                           |
	| File      | Template          | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| Directory | TemplateDirectory | D:\AppShare\DataSuite\Templates                    |
	| Invalid   | InvalidName       |		Test										 |
	Then the Environment Verification Processor result should be
	| canConnect | message                                                                                       |
	| True       | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| True       | Passed connecting to Templates, path: D:\AppShare\DataSuite\Templates                         |
	| False      | Failed, Could not find a valid verifier for name: InvalidName, location: Test                 |