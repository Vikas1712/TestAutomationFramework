Feature: Payment
	As a user I should be able to make payments and buy the product I selected

@Payment
Scenario: Validate user is able to pay for the product added to the cart
	Given User have products added to the cart
	When User makes the payment after filling all details
	Then Confirmation is displayed to the user