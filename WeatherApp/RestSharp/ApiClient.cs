using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;

namespace WeatherApp.RestSharp
{
    public class ApiClient
    {
        private readonly RestClient _client;
        private readonly string _apiKey;
        private RestRequest _restRequest;
        private string _responseString;

        public ApiClient()
        {
            var baseUrl = "https://api.openweathermap.org";
            _apiKey = "dfcced2615c07d4b768267017abf6ab1";
            _client = new RestClient(baseUrl);
        }

        public async Task<string> GetWeeklyWeatherForecast(string lat, string lon)
        {
            var resource = "data/2.5/onecall?lat=" + lat + "&lon=" + lon + "&exclude=hourly,current,minutely&appid=" +
                           _apiKey;

            BuildRequest(resource);
            try
            {
                IRestResponse restResponse = await _client.ExecuteAsync(_restRequest);
                Assert.True(restResponse.StatusCode == HttpStatusCode.OK, "Status code not 200");

                _responseString = restResponse.Content;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return _responseString;
        }

        public async Task<string> GetCurrentWeatherForecast(string cityName)
        {
            var resource = "data/2.5/weather?q=" + cityName + "&appid=" + this._apiKey;
            BuildRequest(resource);
            try
            {
                IRestResponse restResponse = await _client.ExecuteAsync(_restRequest);
                Assert.True(restResponse.StatusCode == HttpStatusCode.OK, "Status code not 200");

                _responseString = restResponse.Content;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return _responseString;
        }

        private void BuildRequest(string resource)
        {
            _restRequest = new RestRequest(resource, Method.GET);
        }
    }
}