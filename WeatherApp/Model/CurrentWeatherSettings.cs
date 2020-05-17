using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Model
{
    public class CurrentWeatherSettings
    {
        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("weather")]
        public List<WeeklyWeather> Weather { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }


        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }


        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("dt")]
        public string Dt { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }


        [JsonProperty("timezone")]
        public string TimeZone { get; set; }


        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cod")]
        public string Cod { get; set; }
    }

    public class Coord
    {
        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }
    }

    public class Sys
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("all")]
        public string All { get; set; }
    }


    public class Wind
    {
        [JsonProperty("speed")]
        public string Speed { get; set; }

        [JsonProperty("deg")]
        public string Deg { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public string Temp { get; set; }

        [JsonProperty("feels_like")]
        public string Feels_like { get; set; }

        [JsonProperty("temp_min")]
        public string Temp_min { get; set; }

        [JsonProperty("Temp_max")]
        public string Temp_max { get; set; }

        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }
    }


    public class WeeklyWeather
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}