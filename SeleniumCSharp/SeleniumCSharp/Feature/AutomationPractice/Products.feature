Feature: Products
	As a user I want to be able to view different products

@Products
Scenario: Validate product information is visible when a product is selected
	Given User is on automation practice site
	When User selects a product from the list
	Then All the details related to products are visible

@Products
Scenario: Validate correct products are loaded based on filter applied
	Given User have selected a category on the website
	When User applys filter to the products
	Then The page is updated with correct products
