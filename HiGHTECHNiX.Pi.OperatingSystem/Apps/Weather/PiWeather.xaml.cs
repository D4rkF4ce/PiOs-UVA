using HiGHTECHNiX.Pi.OperatingSystem.Persistance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace HiGHTECHNiX.Pi.OperatingSystem.Apps.Weather
{
    public sealed partial class PiWeather : UserControl
    {
        public PiWeather()
        {
            this.InitializeComponent();           
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ViewHandler.GetInstance().Switch(PageType.Desktop);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string city = "VIE";
            string country = "Austria";

            location.Text = $"{city},{country}";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"http://api.openweathermap.org/data/2.5/weather?q={city},{country}");
            HttpClient client = new HttpClient();
            var response = client.SendAsync(request).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var bytes = Encoding.Unicode.GetBytes(result);
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    var serializer = new DataContractJsonSerializer(typeof(Weather));
                    var weather = (Weather)serializer.ReadObject(stream);
                    temperature.Text = $"Temperature: {(weather.main.temp - 273.15f):F2} °C";
                }
            }
            else
            {
                temperature.Text = "Error";
            }
        }
    }

    public class Temperature
    {
        public double temp { get; set; }
    }

    public class Weather
    {
        public Temperature main { get; set; }
    }

}
