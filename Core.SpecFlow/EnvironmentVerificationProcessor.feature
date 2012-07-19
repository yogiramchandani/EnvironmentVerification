﻿Feature: Environment Verification Processor
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

Scenario: When 4 Valid Duplicates are passed, check return value
	Given I have a new EnvironmentVerificationProcessor
	When I add items for processing
	| type      | name              | location                                           |
	| File      | Template          | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| File      | Template          | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| File      | Template          | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| File      | Template          | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	Then the Environment Verification Processor result should be
	| canConnect | message                                                                                       |
	| True       | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| True       | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| True       | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |
	| True       | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt |

Scenario: When 2 Valid Duplicates are passed for all types, check return value
	Given I have a new EnvironmentVerificationProcessor
	When I add items for processing
	| type           | name              | location                                                                 |
	| File           | Template          | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt                       |
	| File           | Template          | D:\AppShare\DataSuite\Templates\UtilFunctions.xslt                       |
	| Directory      | TemplateDirectory | D:\AppShare\DataSuite\Templates                                          |
	| Directory      | TemplateDirectory | D:\AppShare\DataSuite\Templates                                          |
	| Database       | Nirvana           | Data Source=.\CDR;Initial Catalog=nirvana_small;Integrated Security=SSPI |
	| Database       | Marshal           | Data Source=.\CDR;Initial Catalog=marshal;Integrated Security=SSPI       |
	| WindowsService | WinService1       | PPF.Levy.WCFHost                                                         |
	| WindowsService | WinService2       | PPF.Levy.WCFHost                                                         |
	| Invalid        | Invalid1          | InvalidLocation1                                                         |
	| Invalid        | Invalid2          | InvalidLocation2                                                         |
	Then the Environment Verification Processor result should be
	| canConnect | message                                                                                                                    |
	| True       | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt                              |
	| True       | Passed connecting to Templates, file path: D:\AppShare\DataSuite\Templates\UtilFunctions.xslt                              |
	| True       | Passed connecting to Templates, path: D:\AppShare\DataSuite\Templates                                                      |
	| True       | Passed connecting to Templates, path: D:\AppShare\DataSuite\Templates                                                      |
	| True       | Passed connecting to Nirvana, connection string : Data Source=.\CDR;Initial Catalog=nirvana_small;Integrated Security=SSPI |
	| True       | Passed connecting to Marshal, connection string : Data Source=.\CDR;Initial Catalog=marshal;Integrated Security=SSPI       |
	| True       | Passed connecting to WinService1, connection string : PPF.Levy.WCFHost                                                     |
	| True       | Passed connecting to WinService2, connection string : PPF.Levy.WCFHost                                                     |
	| False      | Failed, Could not find a valid verifier for name: Invalid1, location: InvalidLocation1                                     |
	| False      | Failed, Could not find a valid verifier for name: Invalid2, location: InvalidLocation2                                     |
