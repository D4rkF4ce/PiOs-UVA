using HiGHTECHNiX.Pi.OperatingSystem.Persistance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Proximity;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace HiGHTECHNiX.Pi.OperatingSystem.Apps.System
{
    public sealed partial class PiSystem : UserControl
    {
        public PiSystem()
        {
            this.InitializeComponent();

            this.lblSystemInfo.Text = "HiGHTECHNiX Raspberry Pi 2 Launcher Version 0.8.2.1" + Environment.NewLine +
                                        "for Windows IoT Core .Net 4.5.2" + Environment.NewLine;

            setSystemInfo();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ViewHandler.GetInstance().Switch(PageType.Desktop);
        }

        private void setSystemInfo()
        {
            EasClientDeviceInformation deviceInfo = new EasClientDeviceInformation();
            lblDeviceName.Text = deviceInfo.FriendlyName;
            lblOperatingSystem.Text = deviceInfo.OperatingSystem;
            lblDeviceType.Text = deviceInfo.SystemProductName;
            lblRootFolder.Text = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            IPAddress ObjIPAddress = GetIPAddress();
            lblIpAdress.Text = ObjIPAddress.ToString();            
        }

        private IPAddress GetIPAddress()
        {
            List<string> IpAddress = new List<string>();

            var Hosts = Windows.Networking.Connectivity.NetworkInformation.GetHostNames().ToList();

            foreach (var Host in Hosts)
            {
                string IP = Host.DisplayName;
                IpAddress.Add(IP);            
            }

            IPAddress address = IPAddress.Parse(IpAddress.Last());
            return address;
        }

    }
}
