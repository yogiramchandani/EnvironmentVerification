Feature: Service Verfication
	In order to verify if a service exists in a system
	As a system user
	I want to be told if the service exists

Scenario: For an existing service, check the result message
	Given I have a new ServiceVerifier
	When I add a service with status, connection name: DHCP Service, connection: Dhcp, status: Running
	Then the result message should be Success connecting to DHCP Service, Key: ServiceName, Value: DhcpKey: ServiceStatus, Value: Running

Scenario: For an existing service, check the result type
	Given I have a new ServiceVerifier
	When I add a service with status, connection name: DHCP Service, connection: Dhcp, status: Running
	Then the result status should be Success

Scenario: For an existing service, check the result count
	Given I have a new ServiceVerifier
	When I add a service with status, connection name: Levy WCF Service, connection: PPF.Levy.WCFHost, status: Running
	Then the result count should be 1
	
Scenario: For a non existent service, check the result message
	Given I have a new ServiceVerifier
	When I add a service with status, connection name: Invalid Service, connection: PPF.Levy.Invalid, status: Running
	Then the result message should be Failure connecting to Invalid Service, Error Message: Service not found, Key: ServiceName, Value: PPF.Levy.InvalidKey: ServiceStatus, Value: Running

Scenario: For a non existent service, check the result type
	Given I have a new ServiceVerifier
	When I add a service with status, connection name: Invalid Service, connection: PPF.Levy.Invalid, status: Running
	Then the result status should be Failure

Scenario: For a non existent service, check the result count
	Given I have a new ServiceVerifier
	When I add a service with status, connection name: Invalid Service, connection: PPF.Levy.Invalid, status: Running
	Then the result count should be 1

Scenario: 3 services are added, check the result count
	Given I have a new ServiceVerifier
	When I add a service with status, connection name: Levy WCF Service, connection: PPF.Levy.WCFHost, status: Running
	When I add a service with status, connection name: Invalid Service, connection: PPF.Levy.Invalid, status: Running
	When I add a service connection name: Invalid Service, connection: PPF.Levy.Invalid
	Then the result count should be 3

