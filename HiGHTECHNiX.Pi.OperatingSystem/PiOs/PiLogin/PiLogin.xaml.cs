using HiGHTECHNiX.Pi.OperatingSystem.Persistance;
using HiGHTECHNiX.Pi.OsEngine;
using HiGHTECHNiX.Pi.SQLight;
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

namespace HiGHTECHNiX.Pi.OperatingSystem.PiOs.PiLogin
{
    public sealed partial class PiLogin : UserControl
    {
        UserGateway _userGateway = new UserGateway();

        public PiLogin()
        {
            this.InitializeComponent();
            this.txtProjectVersion.Text = OsManager.GetInstance().GetOsVersion();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Password))
            {
                var user = _userGateway.GetUser(txtUsername.Text, txtPassword.Password);
                if (user != null)
                {
                    ViewManager.GetInstance().Switch(PageType.Desktop);
                }
            }
        }
    }
}
