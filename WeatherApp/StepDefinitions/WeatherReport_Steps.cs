using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WeatherApp.Model;
using WeatherApp.RestSharp;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Helpers;

namespace WeatherApp.StepDefinitions
{
    [Binding]
    public class WeatherApi
    {
        private List<City> _cityData;
        private WeeklyWeatherSettings _weatherObj;
        private CurrentWeatherSettings _currentWeatherObj;
        private FileHelper _fileHelper;
        private WeatherReport _weatherReport;
        private ApiClient _client;
        private string minTemp;
        private string maxTemp;
        private string hottestDay;

        public WeatherApi(ApiClient client)
        {
            _client = client;
            _cityData = new List<City>();
            _fileHelper = new FileHelper();
            _weatherReport = new WeatherReport();
        }

        [Given(@"I get weather forecast data for the given cities:")]
        public async Task GivenIGetWeatherForecastDataForTheGivenCities(Table table)
        {
            var cities = table.CreateInstance<City>();
            _cityData.Add(cities);

            var response = await _client.GetWeeklyWeatherForecast(cities.Latitude, cities.Longitude);
            _weatherObj = JsonConvert.DeserializeObject<WeeklyWeatherSettings>(response);
        }

        [When(@"I get the hottest day for each city")]
        public void WhenIGetTheHottestDayForEachCity()
        {
            Dictionary<string, decimal> temperature = new Dictionary<string, decimal>();

            foreach (var temp in _weatherObj.Daily)
            {
                var dateInUnix = Convert.ToDouble(temp.Dt);
                var dateObj = new DateHelper();
                var date = dateObj.UnixTimeToDateTime(dateInUnix);
                var num = Convert.ToDecimal(temp.Temp.Day);
                temperature.Add(date, num);
            }

            hottestDay = temperature.FirstOrDefault(x => x.Value == temperature.Values.Max()).Key;
        }

        [Then(@"I create the weather report for '(.*)'")]
        public void ThenICreateTheWeatherReportFor(string cityName)
        {
            CreateHtmlReport(cityName);
        }

        [Given(@"I get the current weather forecast for '(.*)'")]
        public async Task GivenIGetTheCurrentWeatherForecastFor(string cityName)
        {
            string response = await _client.GetCurrentWeatherForecast(cityName);
            _currentWeatherObj = JsonConvert.DeserializeObject<CurrentWeatherSettings>(response);
        }

        [When(@"I get the minimum and maximum temperature")]
        public void WhenIGetTheMinimumAndMaximumTemperature()
        {
            minTemp = _currentWeatherObj.Main.Temp_min;
            maxTemp = _currentWeatherObj.Main.Temp_max;
        }

        [Then(@"I create a report with min and max temperature for '(.*)'")]
        public void ThenICreateAReportWithMinAndMaxTemperatureFor(string cityName)
        {
            CreateHtmlReport(cityName);
        }

        void CreateHtmlReport(string cityName)
        {
            var data = _weatherReport.ConstructCurrentWeatherReportInHtml(minTemp, maxTemp, cityName);
            var fileName = _fileHelper.GetWorkingDirectory() + @"\WeatherReportFiles\CurrentWeatherReport-" + cityName +
                           ".html";
            _fileHelper.CreateAndWriteToFile(fileName, data);
        }
    }
}