Feature: ErrorHandling_API

Scenario Outline: Invalid requests should return an error (Json)
	Given input text is "<input_text>"
	When the request is made to the json endpoint with parameters "<parameters>"
	Then the response error should be "<expected_output>"
Examples:
	| input_text         | parameters                                  | expected_output                                       |
	|                    | none                                        | No Input                                              |
	| this is ass text   | fill_text=this is too long replacement text | User Replacement Text Exceeds Limit of 20 Characters. |
	| this is fuck text  | add=word1,...,word11                        | Invalid Characters in User Black List                 |
	| this is bitch text | add=averylongstringover200characters...     | Invalid Characters in User Black List                 |
	| this is cunt text  | fill_char=@                                 | Invalid User Replacement Characters                   |

Scenario Outline: Invalid requests should return an error (Xml)
	Given input text is "<input_text>"
	When the request is made to the xml endpoint with parameters "<parameters>"
	Then the response error should be "<expected_output>"
Examples:
	| input_text         | parameters                                  | expected_output                                       |
	|                    | none                                        | No Input                                              |
	| this is ass text   | fill_text=this is too long replacement text | User Replacement Text Exceeds Limit of 20 Characters. |
	| this is fuck text  | add=word1,...,word11                        | Invalid Characters in User Black List                 |
	| this is bitch text | add=averylongstringover200characters...     | Invalid Characters in User Black List                 |
	| this is cunt text  | fill_char=@                                 | Invalid User Replacement Characters                   |

Scenario Outline: Invalid requests should return an error (Plain)
	Given input text is "<input_text>"
	When the request is made to the plain endpoint with parameters "<parameters>"
	Then the response error should be "<expected_output>"
Examples:
	| input_text         | parameters                                  | expected_output                                       |
	|                    | none                                        | No Input                                              |
	| this is ass text   | fill_text=this is too long replacement text | User Replacement Text Exceeds Limit of 20 Characters. |
	| this is fuck text  | add=word1,...,word11                        | Invalid Characters in User Black List                 |
	| this is bitch text | add=averylongstringover200characters...     | Invalid Characters in User Black List                 |
	| this is cunt text  | fill_char=@                                 | Invalid User Replacement Characters                   |