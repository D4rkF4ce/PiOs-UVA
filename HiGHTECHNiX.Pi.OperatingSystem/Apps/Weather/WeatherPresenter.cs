using HiGHTECHNiX.Pi.OperatingSystem.Apps.Weather.Models;
using HiGHTECHNiX.Pi.OsEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace HiGHTECHNiX.Pi.OperatingSystem.Apps.Weather
{
    public static class WeatherPresenter
    {
        public static WeatherData GetWeatherData(string country, string city)
        {
            WeatherData data = new WeatherData();

            data.City = city;
            data.Country = country;

            try
            {
                HttpRequestMessage request = 
                    new HttpRequestMessage(
                        HttpMethod.Get, 
                        $"http://api.openweathermap.org/data/2.5/forecast?q={city},{country}&mode=xml&units=metric"
                        );
                HttpClient client = new HttpClient();

                var response = client.SendAsync(request).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(result);

                    data.ForcastData = new Forcast();

                    XmlNodeList allTimes = xmlDoc.GetElementsByTagName("time");
                    data.ForcastData.ForcastList = BuildForcastDataList(allTimes);
                }                
            }
            catch (Exception ex)
            {

            }            

            return data;
        }

        private static List<ForcastData> BuildForcastDataList(XmlNodeList allTimes)
        {
            var forcastList = new List<ForcastData>();

            if (allTimes.Count > 0)
            {
                for (int currentforcast = 0; currentforcast < allTimes.Count; currentforcast++)
                {
                    ForcastData forcastData = new ForcastData();

                    XmlNode time = allTimes.Item(currentforcast);

                    forcastData.From = Convert.ToDateTime(time.Attributes.GetNamedItem("from").InnerText);
                    forcastData.To = Convert.ToDateTime(time.Attributes.GetNamedItem("to").InnerText);

                    if (time.HasChildNodes)
                    {
                        XmlNode symbole = time.ChildNodes.Item(0);
                        forcastData.SymbolNr = Convert.ToInt32(symbole.Attributes.GetNamedItem("number").InnerText);
                        forcastData.SymboleName = symbole.Attributes.GetNamedItem("name").InnerText;
                        var id = symbole.Attributes.GetNamedItem("var").InnerText;
                        var image = new Image();
                        var fullFilePath = String.Format(@"http://openweathermap.org/img/w/{0}.png", id);
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                        forcastData.Symbol = bitmap;

                        XmlNode windDirection = time.ChildNodes.Item(2);
                        forcastData.WindDirection = windDirection.Attributes.GetNamedItem("name").InnerText;
                        forcastData.WindDirectionCode = windDirection.Attributes.GetNamedItem("code").InnerText;
                        forcastData.Degree = windDirection.Attributes.GetNamedItem("deg").InnerText;

                        XmlNode windSpeed = time.ChildNodes.Item(3);
                        forcastData.WindSpeed = windSpeed.Attributes.GetNamedItem("mps").InnerText; // MPS
                        forcastData.WindName = windSpeed.Attributes.GetNamedItem("name").InnerText;

                        XmlNode temperature = time.ChildNodes.Item(4);
                        forcastData.TemperatureValue = temperature.Attributes.GetNamedItem("value").InnerText; // Celsius
                        forcastData.TemperatureMax = temperature.Attributes.GetNamedItem("max").InnerText; // Celsius
                        forcastData.TemperatureMin = temperature.Attributes.GetNamedItem("min").InnerText; // Celsius

                        XmlNode pressure = time.ChildNodes.Item(5);
                        forcastData.Pressure = pressure.Attributes.GetNamedItem("value").InnerText; // hPa

                        XmlNode humidity = time.ChildNodes.Item(6);
                        forcastData.Humidity = Convert.ToInt32(humidity.Attributes.GetNamedItem("value").InnerText); // hPa

                        XmlNode clouds = time.ChildNodes.Item(7);
                        forcastData.Clouds = clouds.Attributes.GetNamedItem("value").InnerText;
                        forcastData.CloudPercent = Convert.ToInt32(clouds.Attributes.GetNamedItem("all").InnerText); // %

                        forcastList.Add(forcastData);
                    }
                }
            }

            return forcastList;
        }

        public static string Wallpaper
        {
            get {
                DateTime now = TimeManager.GetInstance().Now;
                string imgSource = String.Empty;

                if (now.Hour.Between(0, 24))
                    imgSource = "ms-appx:///Apps/Weather/Assets/Backgrounds/night.png";
                if (now.Hour.Between(4, 10))
                    imgSource = "ms-appx:///Apps/Weather/Assets/Backgrounds/morning.png";
                if (now.Hour.Between(9, 16))
                    imgSource = "ms-appx:///Apps/Weather/Assets/Backgrounds/midday.png";
                if (now.Hour.Between(14, 21))
                    imgSource = "ms-appx:///Apps/Weather/Assets/Backgrounds/afternoon.png";


                return imgSource;
            }
        }       
        
    }
}
