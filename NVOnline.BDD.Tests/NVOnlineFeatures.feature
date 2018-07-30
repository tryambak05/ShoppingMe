Feature: SignIn

@NVTests
Scenario Outline: Sign In validations
	Given I have entered credentails <username>, <password> and <appid>
	When I request signin endpoint
	Then the result should be <Message> with <StatusCode>
	Examples: 
	| username               | password   | appid       | Message      | StatusCode |
	| hkhandhedia@nvidia.com | Puja@1234h | SDK Manager | Authorized   | 200        |
	| nraisoni@nvidia.com    | Puja@1234h | SDK Manager | Unauthorized | 401        |
	|                        |            | SDK Manager | Bad Request  | 400        |

@NVTests
Scenario: [HEAD]:api/filecontentsbydocid?docid=1011467

	Given I have entered docId 1011467
	When I request filecontentsbydocid endpoint
	Then the response should be header details with 200 status code
