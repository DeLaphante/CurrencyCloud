Feature: CoreFunctionality_API

Scenario Outline: Profanity filtering core behavior (Json)
	Given input text is "<input_text>"
	When the request is made to the json endpoint
	Then the response should be "<expected_output>"
Examples:
	| input_text             | expected_output        |
	| this is ass text       | this is *** text       |
	| this is fuck text      | this is **** text      |
	| this is bitch text     | this is ***** text     |
	| this is cunt text      | this is **** text      |
	| this is shit text      | this is **** text      |
	| this is class input    | this is class input    |
	| this is clean sentence | this is clean sentence |
	| this is f@ck text      | this is **** text      |

Scenario Outline: Profanity filtering core behavior (Xml)
	Given input text is "<input_text>"
	When the request is made to the xml endpoint
	Then the response should be "<expected_output>"
Examples:
	| input_text             | expected_output        |
	| this is ass text       | this is *** text       |
	| this is fuck text      | this is **** text      |
	| this is bitch text     | this is ***** text     |
	| this is cunt text      | this is **** text      |
	| this is shit text      | this is **** text      |
	| this is class input    | this is class input    |
	| this is clean sentence | this is clean sentence |
	| this is f@ck text      | this is **** text      |

Scenario Outline: Profanity filtering core behavior (Plain)
	Given input text is "<input_text>"
	When the request is made to the plain endpoint
	Then the response should be "<expected_output>"
Examples:
	| input_text             | expected_output        |
	| this is ass text       | this is *** text       |
	| this is fuck text      | this is **** text      |
	| this is bitch text     | this is ***** text     |
	| this is cunt text      | this is **** text      |
	| this is shit text      | this is **** text      |
	| this is class input    | this is class input    |
	| this is clean sentence | this is clean sentence |
	| this is f@ck text      | this is **** text      |

Scenario Outline: Profanity filtering core behavior (Bool)
	Given input text is "<input_text>"
	When the request is made to the containsprofanity endpoint
	Then the response should be "<expected_output>"
Examples:
	| input_text         | expected_output |
	| this is cunt text  | true            |
	| this is clean text | false           |