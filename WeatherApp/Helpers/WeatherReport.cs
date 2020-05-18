using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Model;

namespace WeatherApp.Helpers
{
    public class WeatherReport
    {
        public string ConstructWeatherReportInHtml(WeeklyWeatherSettings weatherSettings, string hottestDay)
        {
            StringBuilder data = new StringBuilder();
            var html = new HtmlHelpers();
            data.AppendLine(html.CreateBody());
            data.AppendLine(html.AddH2Header("Daily forecast for 7 days"));
            data.AppendLine(html.AddH3Header("TimeZone:" + weatherSettings.Timezone));
            data.AppendLine(html.AddH4Header("Hottest day in 7 days: " + hottestDay));
            data.AppendLine(html.AddLineBreak());
            foreach (var item in weatherSettings.Daily)
            {
                double dateInUnix = Convert.ToDouble(item.Dt);
                var dateObj = new DateHelper();
                string date = dateObj.UnixTimeToDateTime(dateInUnix);
                data.AppendLine(html.AddTableHeader());
                data.AppendLine(html.AddDefaultTableStyle());
                data.AppendLine(html.AddRow("Date", date));
                data.AppendLine(html.AddRow("Sunrise", item.Sunrise));
                data.AppendLine(html.AddRow("Sunset", item.Sunset));
                data.AppendLine(html.AddRow("Day temperature", item.Temp.Day));
                data.AppendLine(html.AddRow("Minimum temperature", item.Temp.Min));
                data.AppendLine(html.AddRow("Maximum temperature", item.Temp.Max));
                data.AppendLine(html.AddRow("Night temperature", item.Temp.Night));
                data.AppendLine(html.AddRow("Evening temeprature", item.Temp.Eve));
                data.AppendLine(html.AddRow("Morning temeprature", item.Temp.Morn));
                data.AppendLine(html.AddRow("Pressure", item.Pressure));
                data.AppendLine(html.AddRow("Humidity", item.Humidity));
                data.AppendLine(html.AddRow("Dew point", item.Dew_point));
                data.AppendLine(html.AddRow("Wind Speed", item.Wind_speed));
                data.AppendLine(html.AddRow("Wind degree", item.Wind_deg));
                data.AppendLine(html.AddRow("Clouds", item.Clouds));
                data.AppendLine(html.AddRow("Rain", item.Rain));
                data.AppendLine(html.AddRow("Uvi", item.Uvi));
                foreach (var innerItem in item.Weather)
                {
                    data.AppendLine(html.AddRow("Weather id", innerItem.Id));
                    data.AppendLine(html.AddRow("Weather description", innerItem.Description));
                    data.AppendLine(html.AddRow("Weather main", innerItem.Main));
                    data.AppendLine(html.AddRow("Weather icon", innerItem.Icon));
                }
                data.Append(html.AddTableFooter());
                data.AppendLine(html.AddLineBreak());

            }
            data.Append(html.AddPageFooter());
            return data.ToString();
        }
        public string ConstructCurrentWeatherReportInHtml(string min, string max, string city)
        {
            StringBuilder data = new StringBuilder();
            var html = new HtmlHelpers();
            data.AppendLine(html.CreateBody());
            data.AppendLine(html.AddH2Header("Current weather in " + city));
            data.AppendLine(html.AddH3Header("The minimum temperature is: " + min));
            data.AppendLine(html.AddH3Header("The maximum temperature is: " + max));
            data.AppendLine(html.AddLineBreak());
            data.Append(html.AddPageFooter());
            return data.ToString();
        }
    }
}