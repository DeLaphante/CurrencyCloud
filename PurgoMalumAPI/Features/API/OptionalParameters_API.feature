Feature: OptionalParameters_API

Scenario Outline: Profanity filtering with optional parameters (Json)
	Given input text is "<input_text>"
	When the request is made to the json endpoint with parameters "<parameters>"
	Then the response should be "<expected_output>"
Examples:
	| input_text         | parameters                     | expected_output                   |
	| this is ass text   | fill_text=[censored]           | this is [censored] text           |
	| this is fuck text  | fill_char=_                    | this is ____ text                 |
	| this is bitch text | none                           | this is ***** text                |
	| this is cunt text  | fill_text=xxxxxxxxxxxxxxxxxxxx | this is xxxxxxxxxxxxxxxxxxxx text |
	| this is customWord | add=customWord                 | this is ****                      |
	| this is ShIt text  | none                           | this is **** text                 |

Scenario Outline: Profanity filtering with optional parameters (Xml)
	Given input text is "<input_text>"
	When the request is made to the xml endpoint with parameters "<parameters>"
	Then the response should be "<expected_output>"
Examples:
	| input_text         | parameters                     | expected_output                   |
	| this is ass text   | fill_text=[censored]           | this is [censored] text           |
	| this is fuck text  | fill_char=_                    | this is ____ text                 |
	| this is bitch text | none                           | this is ***** text                |
	| this is cunt text  | fill_text=xxxxxxxxxxxxxxxxxxxx | this is xxxxxxxxxxxxxxxxxxxx text |
	| this is customWord | add=customWord                 | this is ****                      |
	| this is ShIt text  | none                           | this is **** text                 |

Scenario Outline: Profanity filtering with optional parameters (Plain)
	Given input text is "<input_text>"
	When the request is made to the plain endpoint with parameters "<parameters>"
	Then the response should be "<expected_output>"
Examples:
	| input_text         | parameters                     | expected_output                   |
	| this is ass text   | fill_text=[censored]           | this is [censored] text           |
	| this is fuck text  | fill_char=_                    | this is ____ text                 |
	| this is bitch text | none                           | this is ***** text                |
	| this is cunt text  | fill_text=xxxxxxxxxxxxxxxxxxxx | this is xxxxxxxxxxxxxxxxxxxx text |
	| this is customWord | add=customWord                 | this is ****                      |
	| this is ShIt text  | none                           | this is **** text                 |