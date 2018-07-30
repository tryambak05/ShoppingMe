Feature: Customers
	Customer having account holder of ShoppingMe website
	

@customers
Scenario: [GET] : api/v1/getcustomerbyid?customerId=1
	Given I have entered customerId 1
	When I request getcustomerbyId endpoint
	Then the result should be customer details on the screen with 200 status code

@customers
Scenario: [POST] : api/v1/createcustomer
	Given I have entered customer contract objects
	| FirstName | LastName | Email                  | Password  | Mobile     |
	| Pramod    | Swami    | pramod.swami@gmail.com | Pass$#123 | 9890765456 |
	| Varsha    | Balreddi | varsh.reddi@yahoo.com  | Sm@rt#4   | 9876345654 |
	When I request createcustomer endpoint
	Then the result should be true on the screen with 200 status code

@negative
Scenario: [POST] : api/v1/createcustomer : while mobile number as string. It shold be bad request
	Given I have entered customer contract object
	| FirstName | LastName | Email                     | Password  | Mobile  |
	| Pramod    | Swami    | pramod.swami@gmail.com    | Pass$#123 | hfhf133 |
	When I request createcustomer endpoint
	Then the result should be false on the screen with 400 status code

@customers
Scenario: [POST] : api/v1/updatecustomer
	Given I have entered customer contract object
	| FirstName | LastName | Email                  | Password  | Mobile     | CustomerId |
	| Sarita    | Swami    | pramod.swami@gmail.com | Pass$#123 | 9890765456 | 34         |
	When I request updatecustomer endpoint
	Then the multiple result should be true on the screen with 200 status code

@customer
Scenario: [GET] : api/v1/getcustomerbyemail?email=trupt_jundale@gmail.com
	Given I have entered email trupt_jundale@gmail.com
	When I request getcustomerbemail endpoint
	Then the result must be customer details on the screen with 200 status code

@customer
Scenario: [GET]: api/v1/validatecredentialbyemailandpassword?email=tryambak05@gmail.com&password=abc@123
	Given i have entered email tryambak05@gmail.com and password abc@123
	When I request validatecredentialbyemailandpassword endpoint
	Then the result shows status code 200




