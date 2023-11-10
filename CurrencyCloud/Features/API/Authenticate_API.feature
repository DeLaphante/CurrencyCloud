Feature: Authenticate_API


Scenario Outline: Authenticate User Login
	Given the form data has <LoginId> loginId and <ApiKey> apiKey
	When a post form data request is sent to the login endpoint
	Then a <Response> response should be returned

Examples:
	| LoginId | ApiKey  | Response     |
	| valid   | valid   | OK           |
	| invalid | valid   | Unauthorized |
	| valid   | invalid | BadRequest   |
	| null    | null    | BadRequest   |


Scenario Outline: Authenticate User Logout
	Given the form data has valid loginId and valid apiKey
	And a post form data request is sent to the login endpoint
	And a OK response should be returned
	And a <AuthToken> auth token is added as a header
	When a post request is sent  to the logout endpoint
	Then a <Response> response should be returned

Examples:
	| AuthToken | Response     |
	| valid     | OK           |
	| invalid   | Unauthorized |
	| empty     | Unauthorized |
	| none      | Unauthorized |