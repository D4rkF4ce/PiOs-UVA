using HiGHTECHNiX.Pi.SQLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace HiGHTECHNiX.Pi.OsEngine
{
    public static class OsEngine
    {
        public static DateTime SystemDateTime = new DateTime();

        private static UserGateway _userGateway = new UserGateway();

        public static void CheckBasicData()
        {
            if (!_userGateway.BasicDataAvailable())
            {
                _userGateway.CreateBasicData();
            }            
        }

        public static DateTime GetNistTime()
        {
            try
            {
                DateTime dateTime = DateTime.MinValue;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://nist.time.gov/actualtime.cgi?lzbc=siqm9b");
                request.Method = "GET";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader stream = new StreamReader(response.GetResponseStream());
                    string html = stream.ReadToEnd();
                    string time = Regex.Match(html, @"(?<=\btime="")[^""]*").Value;
                    double milliseconds = Convert.ToInt64(time) / 1000.0;
                    dateTime = new DateTime(1970, 1, 1).AddMilliseconds(milliseconds).ToLocalTime();
                }

                // Quick & Dirty Bugfix for TimeZone
                // Add 9 hours for Austria-Time
                return dateTime.AddHours(9);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public static string GetDateTimeToString()
        {
            return SystemDateTime.ToString().Substring(0, SystemDateTime.ToString().Length - 3);
        }

    }
}
