using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WeatherApp.Model;
using WeatherApp.RestSharp;
using System.Linq;
using WeatherApp.Helpers;

namespace WeatherApp.StepDefinitions
{
    [Binding]
    public class Weatherapi : Steps
    {
        public static List<City> cityData = new List<City>();
        public static WeeklyWeatherSettings weatherObj;
        public static CurrentWeatherSettings currentWeatherObj;
        public static string hottestDay;
        public static string minTemp;
        public static string maxTemp;


        [Given(@"I get weather forecast data for the given cities:")]
        public void GivenIGetWeatherForecastDataForTheGivenCities(Table table)
        {
            var cities = table.CreateInstance<City>();
            cityData.Add(cities);
            var client = new ApiClient();
            string response = client.GetWeeklyWeatherForecast(cities.Latitude, cities.Longitude);
            weatherObj = JsonConvert.DeserializeObject<WeeklyWeatherSettings>(response);
        }

        [When(@"I get the hottest day for each city")]
        public void WhenIGetTheHottestDayForEachCity()
        {
            Dictionary<string, decimal> temperature = new Dictionary<string, decimal>();
            foreach (var temp in weatherObj.Daily)
            {
                double dateInUnix = Convert.ToDouble(temp.Dt);
                var dateObj = new DateHelper();
                string date = dateObj.UnixTimeToDateTime(dateInUnix);
                decimal num = Convert.ToDecimal(temp.Temp.Day);
                temperature.Add(date, num);
            }
            hottestDay = temperature.FirstOrDefault(x => x.Value == temperature.Values.Max()).Key;
        }

        [Then(@"I create the weather report for '(.*)'")]
        public void ThenICreateTheWeatherReportFor(string cityName)
        {
            var file = new FileHelper();
            var htmlPage = new WeatherReport();
            string data = htmlPage.ConstructWeatherReportInHtml(weatherObj, hottestDay);
            string fileName = file.GetWorkingDirectory() + @"\WeatherReportFiles\WeeklyWeatherReport-" + cityName + ".html";
            file.CreateAndWriteToFile(fileName, data);
        }

        [Given(@"I get the current weather forecast for '(.*)'")]
        public void GivenIGetTheCurrentWeatherForecastFor(string cityName)
        {
            var client = new ApiClient();
            string response = client.GetCurrentWeatherForecast(cityName);
            currentWeatherObj = JsonConvert.DeserializeObject<CurrentWeatherSettings>(response);
        }

        [When(@"I get the minimum and maximum temperature")]
        public void WhenIGetTheMinimumAndMaximumTemperature()
        {
            minTemp = currentWeatherObj.Main.Temp_min;
            maxTemp = currentWeatherObj.Main.Temp_max;
        }

        [Then(@"I create a report with min and max temperature for '(.*)'")]
        public void ThenICreateAReportWithMinAndMaxTemperatureFor(string cityName)
        {
            var file = new FileHelper();
            var htmlPage = new WeatherReport();
            string data = htmlPage.ConstructCurrentWeatherReportInHtml(minTemp, maxTemp, cityName);
            string fileName = file.GetWorkingDirectory() + @"\WeatherReportFiles\CurrentWeatherReport-" + cityName + ".html";
            file.CreateAndWriteToFile(fileName, data);
        }
    }
}