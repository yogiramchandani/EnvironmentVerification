Feature: Service Verfication
	In order to verify if a service exists in a system
	As a system user
	I want to be told if the service exists

Scenario: For an existing service, check the result message
	Given I have a new ServiceVerifier
	When I add a service connection that exists
	Then the result message should be Passed connecting to Levy WCF Service, connection string : PPF.Levy.WCFHost

Scenario: For an existing service, check the result status
	Given I have a new ServiceVerifier
	When I add a service connection that exists
	Then the result status should be True

Scenario: For an existing service, check the result count
	Given I have a new ServiceVerifier
	When I add a service connection that exists
	Then the result count should be 1
	
Scenario: For a non existent service, check the result message
	Given I have a new ServiceVerifier
	When I add a service connection that does not exists
	Then the result message should be Failed connecting to Invalid Service, connection string : PPF.Levy.Invalid

Scenario: For a non existent service, check the result status
	Given I have a new ServiceVerifier
	When I add a service connection that does not exists
	Then the result status should be False

Scenario: For a non existent service, check the result count
	Given I have a new ServiceVerifier
	When I add a service connection that does not exists
	Then the result count should be 1

Scenario: 3 services are added, check the result count
	Given I have a new ServiceVerifier
	When I add a service connection that exists
	When I add a service connection that does not exists
	When I add a service connection that does not exists
	Then the result count should be 3

