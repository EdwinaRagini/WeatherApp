Feature: Weather
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@weather
Scenario Outline: Weekly weather report is generated for the cities
	Given I get weather forecast data for the given cities:
	| Latitude   | Longitude   | CityName   |
	| <Latitude> | <Longitude> | <CityName> |
	When I get the hottest day for each city 
	Then I create the weather report for '<CityName>'

	Examples: :
	| Latitude  | Longitude  | CityName |
	| 51.507351 | -0.127758  | London   |
	| 48.856613 | 2.352222   | Paris    |
	| 40.416775 | -3.703790  | Madrid   |
	| 38.722252 | -9.139337  | Lisbon   |
	| 40.713054 | -74.007228 | New York |

@weather
Scenario: Get the minimum and maximum temperature for Paris
    Given I get the current weather forecast for 'Paris'
	When I get the minimum and maximum temperature
	Then I create a report with min and max temperature for 'Paris'