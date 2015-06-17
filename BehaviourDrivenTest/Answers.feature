Feature: Ordering answers

Scenario: The answer with the highest vote gets to the top
	Given there is a question "What's your favorite colour?" with the answers
		| Answer         | Vote |
		| Red            | 1    |
		| Cocumber Green | 1    |
	When you upvote answer "Cocumber Green"
	Then the answer "Cocumber Green" should be on the top
