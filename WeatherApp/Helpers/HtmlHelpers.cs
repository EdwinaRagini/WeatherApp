using System;
using System.Collections.Generic;
using System.Text;

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
            string body = String.Format("<h2>{0}</h2>", value);
            return body;
        }

        public string AddH3Header(string value)
        {
            string body = String.Format("<h3>{0}</h3>", value);
            return body;
        }

        public string AddH4Header(string value)
        {
            string body = String.Format("<h4>{0}</h4>", value);
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
            string body = String.Format("<tr><th>{0}</th><td>{1}</td></tr>", key, value);
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