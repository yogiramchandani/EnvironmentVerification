Feature: Service Verfication
	In order to verify if a service exists in a system
	As a system user
	I want to be told if the service exists

Scenario: For an existing service, check the result message
	Given I have a new ServiceVerifier
	When I add a service connection name: Levy WCF Service, connection: PPF.Levy.WCFHost
	Then the result message should be Success connecting to Levy WCF Service, connection string : PPF.Levy.WCFHost

Scenario: For an existing service, check the result type
	Given I have a new ServiceVerifier
	When I add a service connection name: Levy WCF Service, connection: PPF.Levy.WCFHost
	Then the result status should be Success

Scenario: For an existing service, check the result count
	Given I have a new ServiceVerifier
	When I add a service connection name: Levy WCF Service, connection: PPF.Levy.WCFHost
	Then the result count should be 1
	
Scenario: For a non existent service, check the result message
	Given I have a new ServiceVerifier
	When I add a service connection name: Invalid Service, connection: PPF.Levy.Invalid
	Then the result message should be Failure connecting to Invalid Service, connection string : PPF.Levy.Invalid

Scenario: For a non existent service, check the result type
	Given I have a new ServiceVerifier
	When I add a service connection name: Invalid Service, connection: PPF.Levy.Invalid
	Then the result status should be Failure

Scenario: For a non existent service, check the result count
	Given I have a new ServiceVerifier
	When I add a service connection name: Invalid Service, connection: PPF.Levy.Invalid
	Then the result count should be 1

Scenario: 3 services are added, check the result count
	Given I have a new ServiceVerifier
	When I add a service connection name: Levy WCF Service, connection: PPF.Levy.WCFHost
	When I add a service connection name: Invalid Service, connection: PPF.Levy.Invalid
	When I add a service connection name: Invalid Service, connection: PPF.Levy.Invalid
	Then the result count should be 3

