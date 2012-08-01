Feature: Database Verfication
	In order to verify if a database exists in a system
	As a system user
	I want to be told if the database exists

Scenario: For an existing database check the result string
	Given I have a new DatabaseVerifier
	When I add the DataBase connection name: Nirvana, connection: Data Source=.\CDR;Initial Catalog=nirvana_small;Integrated Security=SSPI
	Then the first result message on the screen should be Success connecting to Nirvana, Key: ConnectionString, Value: Data Source=.\CDR;Initial Catalog=nirvana_small;Integrated Security=SSPI
	
Scenario: For an existing database check if result type
	Given I have a new DatabaseVerifier
	When I add the DataBase connection name: Nirvana, connection: Data Source=.\CDR;Initial Catalog=nirvana_small;Integrated Security=SSPI
	Then the first result verification on the screen should be Success
	
Scenario: For an existing database check the result count
	Given I have a new DatabaseVerifier
	When I add the DataBase connection name: Nirvana, connection: Data Source=.\CDR;Initial Catalog=nirvana_small;Integrated Security=SSPI
	Then the count of messages should be 1

Scenario: For a non existent database check the result string
	Given I have a new DatabaseVerifier
	When I add the DataBase connection name: NirvanaNotExists, connection: Data Source=.\CDR;Initial Catalog=nirvana_notExists;Integrated Security=SSPI
	Then the first result message on the screen should be Failure connecting to NirvanaNotExists, Error Message: , Key: ConnectionString, Value: Data Source=.\CDR;Initial Catalog=nirvana_notExists;Integrated Security=SSPI

Scenario: For a non existent database check if result type
	Given I have a new DatabaseVerifier
	When I add the DataBase connection name: NirvanaNotExists, connection: Data Source=.\CDR;Initial Catalog=nirvana_notExists;Integrated Security=SSPI
	Then the first result verification on the screen should be Failure
	
Scenario: For a non existent database check the result count
	Given I have a new DatabaseVerifier
	When I add the DataBase connection name: NirvanaNotExists, connection: Data Source=.\CDR;Initial Catalog=nirvana_notExists;Integrated Security=SSPI
	Then the count of messages should be 1
	
Scenario: 3 Database connections added check the result count
	Given I have a new DatabaseVerifier
	When I add the DataBase connection name: Nirvana, connection: Data Source=.\CDR;Initial Catalog=nirvana_small;Integrated Security=SSPI
	When I add the DataBase connection name: Nirvana, connection: Data Source=.\CDR;Initial Catalog=nirvana_small;Integrated Security=SSPI
	When I add the DataBase connection name: NirvanaNotExists, connection: Data Source=.\CDR;Initial Catalog=nirvana_notExists;Integrated Security=SSPI
	Then the count of messages should be 3
