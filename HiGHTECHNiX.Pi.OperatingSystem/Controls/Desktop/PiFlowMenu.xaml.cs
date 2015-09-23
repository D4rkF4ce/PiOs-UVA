using HiGHTECHNiX.Pi.OperatingSystem.Persistance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace HiGHTECHNiX.Pi.OperatingSystem.Controls.Desktop
{
    public sealed partial class PiFlowMenu : UserControl
    {
        private readonly static PiFlowMenu _instance = new PiFlowMenu();
        public static PiFlowMenu GetInstance()
        {
            return _instance;
        }

        public PiFlowMenu()
        {
            this.InitializeComponent();            
        }

        private void btnLockScreen_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.GetInstance().Switch(PageType.Login);
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            ShutdownHelper(ShutdownKind.Restart);
        }

        private void btnShutdown_Click(object sender, RoutedEventArgs e)
        {
            ShutdownHelper(ShutdownKind.Shutdown);
        }

        private void ShutdownHelper(ShutdownKind kind)
        {
            try
            {
                ShutdownManager.BeginShutdown(kind, TimeSpan.FromSeconds(0.5));
            }
            catch (Exception ex)
            {
                
            }
        }


        private void btnWeather_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.GetInstance().Switch(PageType.Weather);
        }

        private void btnWebBrowser_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.GetInstance().Switch(PageType.WebBrowser);
        }

        private void btnSystem_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.GetInstance().Switch(PageType.System);
        }
    }
}
