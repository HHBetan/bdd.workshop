Feature: CubeRoot
	As Alice (the customer)
	I want to know the cube root of a number
	So I can organize my inventory

Scenario Outline: Checking several cube roots
	When number <number> is added for cube root
	Then the result of the cube root is <result>
	Examples:
	| number | result |
	| 1		 | 1	  |
	| 2		 | 1.26   |
	| 3		 | 1.44   |
	| 4		 | 1.59   |
	| 5		 | 1.71   |
	| 6		 | 1.82   |
	| 7		 | 1.91   |
	| 8		 | 2	  |	  
	| 9		 | 2.08   |
	| 10	 | 2.15   |
	| 16	 | 2.52   |
	| 20	 | 2.71   |
	| 25	 | 2.92   |
	| 27	 | 3	  |
	| 30	 | 3.11   |
	| 36	 | 3.30   |
	| 49	 | 3.65   |
	| 64	 | 4	  |	  
	| 81	 | 4.33   |
	| 100    | 4.64   |
	| 121    | 4.95   |