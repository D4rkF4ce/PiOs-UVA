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
        MainPage _root;

        private readonly static PiTaskbar _instance = new PiTaskbar();
        public static PiTaskbar GetInstance()
        {
            return _instance;
        }

        public PiTaskbar()
        {
            this.InitializeComponent();
            SyncSystemTime();
        }

        public void SetMainWindow(MainPage parent)
        {
            _root = parent;
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
            ViewManager.GetInstance().TogglePiFlowMenu();
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

        private void btnPiClock_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TimeManager.GetInstance().SyncTime();
                string msg = "Time sync successfully! It's now: " + TimeManager.GetInstance().Now.ToString();
                NotifyManager.GetInstance().NotifyUser("Time Sync Message", msg, NotifyType.StatusMessage, NotifyButton.Ok);
            }
            catch (Exception ex)
            {
                NotifyManager.GetInstance().NotifyUser("Time Sync Error", ex.StackTrace, NotifyType.ErrorMessage, NotifyButton.Ok);
            }            
        }
    }
}
