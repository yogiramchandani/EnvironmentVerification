Feature: Verification Processor
	In order to process a batch of environment artifacts
	As a service user 
	I want to be told the status of all the artifacts

Scenario: When 3 items are passed, check for count
	Given I have a new EnvironmentVerificationProcessor
	When I add items for processing
	| type      | name              | key           | value                                              |
	| File      | Template          | FilePath      | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| Directory | TemplateDirectory | DirectoryPath | D:\AppShare\DataSuite\Templates                    |
	| Invalid   | InvalidName       | Invalid       | Test                                               |
	Then the Environment Verification Processor result count should be 3

Scenario: When 2 Valid and 1 invalid items are passed, check return value
	Given I have a new EnvironmentVerificationProcessor
	When I add items for processing
	| type      | name              | key           | value                                              | 
	| File      | Template          | FilePath      | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| Directory | TemplateDirectory | DirectoryPath | D:\AppShare\DataSuite\Templates                    |
	| Invalid   | InvalidName       | Invalid       | Test                                               |
	Then the Environment Verification Processor result should be
	| Type    | Message                                                                                       |
	| Success | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| Success | Passed connecting to Templates, path: D:\AppShare\DataSuite\Templates                         |
	| Failure | Failed, Could not find a valid verifier for name: InvalidName, location: Test                 |

Scenario: When 4 Valid Duplicates are passed, check return value
	Given I have a new EnvironmentVerificationProcessor
	When I add items for processing
	| type | name     | key      | value                                              |
	| File | Template | FilePath | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| File | Template | FilePath | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| File | Template | FilePath | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| File | Template | FilePath | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	Then the Environment Verification Processor result should be
	| Type    | Message                                                                                       |
	| Success | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| Success | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| Success | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| Success | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |

Scenario: When 2 Valid Duplicates are passed for all types, check return value
	Given I have a new EnvironmentVerificationProcessor
	When I add items for processing
	| type           | name              | key              | value                                                                    | key1          | value1  |
	| File           | Template          | FilePath         | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt                       |               |         |
	| File           | Template          | FilePath         | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt                       |               |         |
	| Directory      | TemplateDirectory | DirectoryPath    | D:\AppShare\DataSuite\Templates                                          |               |         |
	| Directory      | TemplateDirectory | DirectoryPath    | D:\AppShare\DataSuite\Templates                                          |               |         |
	| Database       | Nirvana           | ConnectionString | Data Source=.\CDR;Initial Catalog=nirvana_small;Integrated Security=SSPI |               |         |
	| Database       | Marshal           | ConnectionString | Data Source=.\CDR;Initial Catalog=marshal;Integrated Security=SSPI       |               |         |
	| WindowsService | WinService1       | ServiceName      | Dhcp                                                                     | ServiceStatus | Running |
	| WindowsService | WinService2       | ServiceName      | Dhcp                                                                     | ServiceStatus | Running |
	| Invalid        | Invalid1          | Invalid          | InvalidLocation1                                                         |               |         |
	| Invalid        | Invalid2          | Invalid          | InvalidLocation2                                                         |               |         |
	Then the Environment Verification Processor result should be
	| Type    | Message                                                                                                                    |
	| Success | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt                              |
	| Success | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt                              |
	| Success | Passed connecting to Templates, path: D:\AppShare\DataSuite\Templates                                                      |
	| Success | Passed connecting to Templates, path: D:\AppShare\DataSuite\Templates                                                      |
	| Success | Passed connecting to Nirvana, connection string : Data Source=.\CDR;Initial Catalog=nirvana_small;Integrated Security=SSPI |
	| Success | Passed connecting to Marshal, connection string : Data Source=.\CDR;Initial Catalog=marshal;Integrated Security=SSPI       |
	| Success | Passed connecting to WinService1, connection string : Dhcp                                                                 |
	| Success | Passed connecting to WinService2, connection string : Dhcp                                                                 |
	| Failure | Failed, Could not find a valid verifier for name: Invalid1, location: InvalidLocation1                                     |
	| Failure | Failed, Could not find a valid verifier for name: Invalid2, location: InvalidLocation2                                     |
