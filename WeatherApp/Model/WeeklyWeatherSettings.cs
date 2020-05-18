using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherApp.Model
{
    public class WeeklyWeatherSettings
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("daily")]
        public List<Daily> Daily { get; set; }
    }

    public class Daily
    {
        [JsonProperty("dt")]
        public string Dt { get; set; }

        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }

        [JsonProperty("temp")]
        public Temp Temp { get; set; }

        [JsonProperty("feelsLike")]
        public FeelsLike Feelslike { get; set; }

        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        [JsonProperty("dew_point")]
        public string Dew_point { get; set; }

        [JsonProperty("wind_speed")]
        public string Wind_speed { get; set; }

        [JsonProperty("wind_deg")]
        public string Wind_deg { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("clouds")]
        public string Clouds { get; set; }

        [JsonProperty("rain")]
        public string Rain { get; set; }

        [JsonProperty("uvi")]
        public string Uvi { get; set; }
    }

    public class Temp
    {
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("min")]
        public string Min { get; set; }

        [JsonProperty("max")]
        public string Max { get; set; }

        [JsonProperty("night")]
        public string Night { get; set; }

        [JsonProperty("eve")]
        public string Eve { get; set; }

        [JsonProperty("morn")]
        public string Morn { get; set; }
    }

    public class FeelsLike
    {
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("night")]
        public string Night { get; set; }

        [JsonProperty("eve")]
        public string Eve { get; set; }

        [JsonProperty("morn")]
        public string Morn { get; set; }
    }

    public class Weather
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