﻿Feature: Database Verfication
	In order to verify if a database exists in a system
	As a system user
	I want to be told if the database exists

Scenario: For an existing database check the result string
	Given I have a new DatabaseVerifier
	When I add a DataBase connection that exists
	Then the first result message on the screen should be Passed connecting to Nirvana, connection string : Data Source=.\CDR;Initial Catalog=nirvana_small;Integrated Security=SSPI
	
Scenario: For an existing database check if can connect
	Given I have a new DatabaseVerifier
	When I add a DataBase connection that exists
	Then the first result verification on the screen should be True
	
Scenario: For an existing database check the result count
	Given I have a new DatabaseVerifier
	When I add a DataBase connection that exists
	Then the count of messages should be 1

Scenario: For a non existent database check the result string
	Given I have a new DatabaseVerifier
	When I add a DataBase connection that does not exist
	Then the first result message on the screen should be Failed connecting to NirvanaNotExists, connection string : Data Source=.\CDR;Initial Catalog=nirvana_notExists;Integrated Security=SSPI

Scenario: For a non existent database check if can connect
	Given I have a new DatabaseVerifier
	When I add a DataBase connection that does not exist
	Then the first result verification on the screen should be False
	
Scenario: For a non existent database check the result count
	Given I have a new DatabaseVerifier
	When I add a DataBase connection that does not exist
	Then the count of messages should be 1
	
Scenario: 3 Database connections added check the result count
	Given I have a new DatabaseVerifier
	When I add a DataBase connection that exists
	When I add a DataBase connection that exists
	When I add a DataBase connection that does not exist
	Then the count of messages should be 3
