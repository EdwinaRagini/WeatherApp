using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Helpers
{
    public class DateHelper
    {
        public string UnixTimeToDateTime(double value)
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(value);
            string newDate = dateTime.GetDateTimeFormats('d')[0];
            return newDate;
        }
    }
}