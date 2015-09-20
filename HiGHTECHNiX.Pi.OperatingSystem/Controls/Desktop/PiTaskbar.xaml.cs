using HiGHTECHNiX.Pi.OperatingSystem.Persistance;
using HiGHTECHNiX.Pi.OsEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace HiGHTECHNiX.Pi.OperatingSystem.Controls.Desktop
{
    public sealed partial class PiTaskbar : UserControl
    {
        DispatcherTimer _timer = new DispatcherTimer();
        MainPage _mainPage;

        public PiTaskbar(MainPage mainPage)
        {
            this.InitializeComponent();
            _mainPage = mainPage;

            SyncSystemTime();
        }

        private void _timer_Tick(object sender, object e)
        {
            try
            {
                this.btnPiClock.Content = TimeManager.GetInstance().Now.ToString().Substring(0, TimeManager.GetInstance().Now.ToString().Length - 3);
            }
            catch (Exception) { }
        }

        private void btnPiStart_Click(object sender, RoutedEventArgs e)
        {
            _mainPage.TogglePiFlowMenu();
        }

        private void btnPiWebBrowser_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.GetInstance().Switch(PageType.WebBrowser);
        }

        private void btnPiWeather_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.GetInstance().Switch(PageType.Weather);
        }

        private void SyncSystemTime()
        {
            _timer.Tick += _timer_Tick;
            this.btnPiClock.Content = TimeManager.GetInstance().Now.ToString().Substring(0, TimeManager.GetInstance().Now.ToString().Length -3);
            _timer.Interval = new TimeSpan(0, 1, 0);
            _timer.Start();
        }

        private void btnPiSystem_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.GetInstance().Switch(PageType.System);
        }

        private void btnMediaPlayer_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.GetInstance().ToggleWidget(Widget.MediaPlayer);
        }
    }
}
