Feature: Cards_Feature
As a user I want to create card for ToDO, Doing and Done in Trello Board

Background: 
	Given The user is on a Trello board
	
@Card
Scenario: The user can add a ToDo new card
    Given Register User is on the Card page
    When User create a new card with title "Adding title into To Do Card Lane" in ToDo Lane
   	Then That new to do card is added successfully on the board
 
@Card  	  	
Scenario: The user can add a Doing new card
	Given Register User is on the Card page
	When User create a new card with title "Adding title into Doing Card Lane" in Doing Lane
	Then That new to do card is added successfully on the board   	
	
@Card  	  	
Scenario: The user can add a Done new card
	Given Register User is on the Card page
	When User create a new card with title "Adding title into Done Card Lane" in Done Lane
	Then That new to do card is added successfully on the board 

@Card  	  	
Scenario: The user can delete a Done new card
	Given User can view the Card on the board
	When User deletes all the cards
	And User delete the active board too
	Then That cards are no longer visible on board 	
	