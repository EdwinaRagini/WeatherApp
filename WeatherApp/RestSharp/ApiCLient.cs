using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using RestSharp;


namespace WeatherApp.RestSharp
{
    public class ApiClient
    {
        private readonly RestClient client;
        private readonly string apiKey;
        private readonly string baseUrl;

        public ApiClient()
        {
            this.baseUrl = "https://api.openweathermap.org";
            this.apiKey = "dfcced2615c07d4b768267017abf6ab1";
            this.client = new RestClient(baseUrl);
        }

        public string GetWeeklyWeatherForecast(string lat, string lon)
        {
            RestRequest request = new RestRequest("data/2.5/onecall?lat=" + lat + "&lon=" + lon + "&exclude=hourly,current,minutely&appid=" + this.apiKey, Method.GET);
            IRestResponse restResponse = client.Execute(request);
            return restResponse.Content;
        }

        public string GetCurrentWeatherForecast(string cityName)
        {
            RestRequest request = new RestRequest("data/2.5/weather?q=" + cityName + "&appid=" + this.apiKey, Method.GET);
            IRestResponse restResponse = client.Execute(request);
            return restResponse.Content;
        }
    }

}