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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace HiGHTECHNiX.Pi.OperatingSystem.Controls.Desktop
{
    public sealed partial class PiFlowMenu : UserControl
    {
        public PiFlowMenu()
        {
            this.InitializeComponent();
        }

        private void btnLockScreen_Click(object sender, RoutedEventArgs e)
        {
            ViewHandler.GetInstance().Switch(PageType.Login);
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
    }
}
