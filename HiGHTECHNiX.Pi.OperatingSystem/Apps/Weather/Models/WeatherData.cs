using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace HiGHTECHNiX.Pi.OperatingSystem.Apps.Weather.Models
{
    public class WeatherData
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string CityLocation { get; set; }

        public DateTime SunRise { get; set; }
        public DateTime SunSet { get; set; }

        public Forcast ForcastData { get; set; }
    }

    public class Forcast
    {
        public List<ForcastData> ForcastList { get; set; }
    }

    public class ForcastData
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public BitmapImage Symbol { get; set; }
        public int SymbolNr { get; set; }
        public string SymboleName { get; set; }
        public string IconValue { get; set; }

        public string WindDirection { get; set; }
        public string WindDirectionCode { get; set; }
        public string Degree { get; set; }
        public string WindSpeed { get; set; }
        public string WindName { get; set; }

        public string TemperatureValue { get; set; }
        public string TemperatureMin { get; set; }
        public string TemperatureMax { get; set; }

        public string Pressure { get; set; }
        public int Humidity { get; set; }

        public string Clouds { get; set; }
        public int CloudPercent { get; set; }
    }
}
