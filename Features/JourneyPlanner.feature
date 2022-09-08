Feature: Journey Planner

Background: 
Given I am on plan a journey page

Scenario Outline: 01 Verifying valid journey
	When I enter from "<From>" and to "<To>" locations and click on plan my journey
	Then I should see my journey results

	Examples:
		| From                        | To        |
		| Holborn Underground Station | Stratford |

Scenario Outline: 02 Verifying Invalid journey when the location name is incorrect
	When I enter from "<From>" and to "<To>" locations and click on plan my journey
	Then I should not see any journey results

	Examples:
		| From                        | To  |
		| Holborn Underground Station | hhh |

Scenario Outline: 03 Verifying Invalid journey when no location entered
	When I enter from "<From>" and to "<To>" locations and click on plan my journey
	Then I should get following field validation error message "The From field is required."

	Examples:
		| From | To        |
		|      | Stratford |

Scenario Outline: 04 Plan a journey based on arrival time
	When I click on change time
	And I select Arrival
	And I enter from "<From>" and to "<To>" locations and click on plan my journey
	Then I should see my journey results

	Examples:
		| From                        | To        |
		| Holborn Underground Station | Stratford |

Scenario Outline: 05 Amend Journey
	When I enter from "<From>" and to "<To>" locations and click on plan my journey
	Then I amend the to location as "<UpdateToLocation>"

	Examples:
		| From                        | To        | UpdateToLocation |
		| Holborn Underground Station | Stratford | North Greenwich  |

Scenario: 06 Check recent planned journies
	When I click on recent tab
	Then I should see results on the recent tab





