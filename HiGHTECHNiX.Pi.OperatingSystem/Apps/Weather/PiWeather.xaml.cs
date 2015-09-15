using HiGHTECHNiX.Pi.OperatingSystem.Apps.Weather.Models;
using HiGHTECHNiX.Pi.OperatingSystem.Persistance;
using HiGHTECHNiX.Pi.OsEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace HiGHTECHNiX.Pi.OperatingSystem.Apps.Weather
{
    public sealed partial class PiWeather : UserControl
    {
        public PiWeather()
        {
            this.InitializeComponent();
            DesktopBackground.Source = new BitmapImage(new Uri(WeatherPresenter.Wallpaper));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ViewHandler.GetInstance().Switch(PageType.Desktop);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            WeatherData data = WeatherPresenter.GetWeatherData("AUSTRIA", "VIENNA");
            lblLocation.Text = $"{data.City},{data.Country}";

            var list = data.ForcastData.ForcastList.OrderBy(x => x.From);
            int today = TimeManager.Now.Day;
            int tomorrow = today + 1;
            int dayAfter = today + 2;

            lblToday.Text = TimeManager.Now.ToString("dddd");
            imgToday.Source = list.First(x => x.From.Day == today).Symbol;
            lblTodayC.Text = list.First(x => x.From.Day == today).TemperatureValue + "C°";

            lblTomorrow.Text = TimeManager.Now.AddDays(1).ToString("dddd");
            imgTomorrow.Source = list.First(x => x.From.Day == tomorrow).Symbol;
            lblTomorrowC.Text = list.First(x => x.From.Day == tomorrow).TemperatureValue + "C°";

            lblDayAfter.Text = TimeManager.Now.AddDays(2).ToString("dddd");
            imgDayAfter.Source = list.First(x => x.From.Day == dayAfter).Symbol;
            lblDayAfterC.Text = list.First(x => x.From.Day == dayAfter).TemperatureValue + "C°";
        }

    }  
}
