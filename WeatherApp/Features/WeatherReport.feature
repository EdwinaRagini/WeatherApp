﻿Feature: Weather
	As a user of open weather api user
	I would like to get the weather data
	and generate weather reports

#Calls the One Call API to get the weekly weather report
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

#Calls the Current Weather Data API to get the current weather data for a city
@weather
Scenario: Get the minimum and maximum temperature for Paris
    Given I get the current weather forecast for 'Paris'
	When I get the minimum and maximum temperature
	Then I create a report with min and max temperature for 'Paris'
