using HiGHTECHNiX.Pi.OperatingSystem.Persistance;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace HiGHTECHNiX.Pi.OperatingSystem.Apps.WebBrowser
{
    public sealed partial class PiWebBrowser : UserControl
    {
        public PiWebBrowser()
        {
            this.InitializeComponent();
            txtWebAdress.Text = "https://www.google.at";
            DoWebNavigate();
        }

        private void btnGoWeb_Click(object sender, RoutedEventArgs e)
        {            
            DoWebNavigate();
        }

        private void DoWebNavigate()
        {
            if (txtWebAdress.Text.Length > 0)
            {
                Uri url = new Uri(txtWebAdress.Text);
                webView.Navigate(url);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.webView.Stop();
            txtWebAdress.Text = "https://www.google.at";
            DoWebNavigate();
            ViewHandler.GetInstance().Switch(PageType.Desktop);
        }

        private void btnGoYT_Click(object sender, RoutedEventArgs e)
        {
            txtWebAdress.Text = "https://youtube.com";
            DoWebNavigate();
        }

        private void btnGoGoggle_Click(object sender, RoutedEventArgs e)
        {
            txtWebAdress.Text = "https://www.google.at";
            DoWebNavigate();
        }

        private void btnFb_Click(object sender, RoutedEventArgs e)
        {
            txtWebAdress.Text = "https://www.facebook.com";
            DoWebNavigate();
        }

        private void webView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            txtWebAdress.Text = args.Uri.ToString();
        }
    }
}
