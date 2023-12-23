Feature: SquareRoot
	As Alice (the customer)
	I want to know the square root of a number
	So I can organize my inventory

Scenario Outline: Checking several square roots
	When number <number> is added
	Then the result of the square root is <result>
	Examples:
| number | result |
	| 2      | 1.41   |
	| 3      | 1.73   |
	| 4      | 2      |
	| 5      | 2.24   |
	| 6      | 2.45   |
	| 7      | 2.65   |
	| 8      | 2.83   |
	| 9      | 3      |
	| 10     | 3.16   |
	| 16     | 4      |
	| 20     | 4.47   |
	| 25     | 5      |
	| 30     | 5.47   |
	| 36     | 6      |
	| 49     | 7      |
	| 64     | 8      |
	| 81     | 9      |
	| 100    | 10     |
	| 121    | 11     |