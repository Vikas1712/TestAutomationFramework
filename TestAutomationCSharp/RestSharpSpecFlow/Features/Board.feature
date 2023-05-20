Feature: Create a Trello Board
As a user of the Trello API
I want to be able to create a new board
So that I can organize my tasks effectively

Scenario: Create a new Trello board
    Given I have a valid Trello API key and token
    When I send a POST request to the "/1/boards/" endpoint with the following data:
       | Parameter    | Value                            |
       | key          | a5bfab77269c848d4a9458fe7a3449a9 |
       | token        | ATTA92d124b3cee4c08870dbf6299eb06e300fcb9e4a6e80cbf3c263195ecc7985da20758DAC|
       | name         | RestSharp                     |
       | defaultLists | true                          |
    Then the response status code should be 200
    And the response should contain the created board's ID
    
Scenario Outline: Create a new Trello board with Multiple dataset
    Given I have a valid Trello API key and token
    When I send a POST request to the "/1/boards/" endpoint with the following data:
       | Parameter    | Value         |
       | key          | <apiKey>      |
       | token        | <apiToken>    |
       | name         | <boardName>   |
       | defaultLists | <defaultList> |
    Then the response status code should be <statusCode>
    And the response should contain the created board's ID   
    Examples: 
    | apiKey                           | apiToken                                                                     | boardName | defaultList | statusCode |
    | a5bfab77269c848d4a9458fe7a3449a9 | ATTA92d124b3cee4c08870dbf6299eb06e300fcb9e4a6e80cbf3c263195ecc7985da20758DAC | RestSharp | true        |     200    |
    | a5bfab77269c848d4a9458fe7a3449a9 | ATTA92d124b3cee4c08870dbf6299eb06e300fcb9e4a6e80cbf3c263195ecc7985da20758DAC | RestSharp | false       |     200    |
    | invalidAPIKey                    | ATTA92d124b3cee4c08870dbf6299eb06e300fcb9e4a6e80cbf3c263195ecc7985da20758DAC | RestSharp | true        |     401    |
    | a5bfab77269c848d4a9458fe7a3449a9 | invalidAPIToken                                                              | RestSharp | true        |     401    |