Feature: SearchForComputer

Background: 
	When I create the computer with unique name
	Then response message should contain "Done!"
	And response code should be "OK"

@SearchTests
Scenario: Search for the computer with unique name
	When I search for the computer
	Then response message should contain "One computer found"
	And response code should be "OK"