using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace HiGHTECHNiX.Pi.OsEngine
{
    public sealed class TimeManager
    {
        private static DispatcherTimer _timer = new DispatcherTimer();
        private static DateTime _time;

        private readonly static TimeManager _instance = new TimeManager();
        public static TimeManager GetInstance()
        {
            return _instance;
        }

        private TimeManager()
        {
            // only for private using !! 
        }

        public DateTime Now
        {
            get
            {                
                return _time;
            }            
        }

        public bool SyncTime()
        {
            try
            {
                _time = DateTime.MinValue;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://time.hightechnix.at/Time/GetTime");
                request.Method = "GET";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader stream = new StreamReader(response.GetResponseStream());
                    string html = stream.ReadToEnd();

                    if (!String.IsNullOrEmpty(html))
                    {
                        string dateText = html.TrimStart();
                        _time = Convert.ToDateTime(dateText);

                        if (!_timer.IsEnabled)
                        {
                            _timer.Interval = new TimeSpan(0, 0, 1);
                            _timer.Tick += _timer_Tick;
                            _timer.Start();
                        }                        

                        return true;
                    }
                }
            }
            catch (Exception)
            {

            }

            return false;
        }

        private static void _timer_Tick(object sender, object e)
        {
            _time = _time.AddSeconds(1);
        }
        
    }
}
