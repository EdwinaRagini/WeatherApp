using System;

namespace WeatherApp.Helpers
{
    public class HtmlHelpers
    {
        public string CreateBody()
        {
            string body = "<html><body>";
            return body;
        }

        public string AddH2Header(string value)
        {
            string body = $"<h2>{value}</h2>";
            return body;
        }

        public string AddH3Header(string value)
        {
            string body = $"<h3>{value}</h3>";
            return body;
        }

        public string AddH4Header(string value)
        {
            string body = $"<h4>{value}</h4>";
            return body;

        }
        public string AddDefaultTableStyle()
        {
            string body = "<style>table,th,td{border:1px solid black;}</style>";
            return body;
        }
        public string AddTableHeader()
        {
            string body = "<table>";
            return body;
        }

        public string AddLineBreak()
        {
            string body = "<br>";
            return body;
        }

        public string AddRow(string key, string value)
        {
            string body = $"<tr><th>{key}</th><td>{value}</td></tr>";
            return body;
        }

        public string AddPageFooter()
        {
            string body = "</body></html>";
            return body;
        }

        public string AddTableFooter()
        {
            string body = "</table>";
            return body;
        }
    }
}