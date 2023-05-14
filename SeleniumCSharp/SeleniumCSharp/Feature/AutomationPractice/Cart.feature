Feature: Cart
	As A user I want to be able to maintain products in my cart

@Cart
Scenario: Validate the product is added to the cart
	Given Register User is on the product page
	When User adds a product to the cart
	Then The cart should be updated

@Cart
Scenario: Validate the cart is updated when products are removed
	Given User have added few products in the cart
	When User removes a product from the cart
	Then The cart should be empty