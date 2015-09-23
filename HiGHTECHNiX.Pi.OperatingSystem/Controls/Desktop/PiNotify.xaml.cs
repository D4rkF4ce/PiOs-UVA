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

namespace HiGHTECHNiX.Pi.OperatingSystem.Controls.Desktop
{
    public sealed partial class PiNotify : UserControl
    {
        private readonly static PiNotify _instance = new PiNotify();
        public static PiNotify GetInstance()
        {
            return _instance;
        }

        public PiNotify()
        {
            this.InitializeComponent();
        }

        public void SetNotification(string title, string message, NotifyType type, NotifyButton button)
        {
            switch (button)
            {
                case NotifyButton.Ok:
                    this.btnOK.Visibility = Visibility.Visible;
                    this.btnCancel.Visibility = Visibility.Collapsed;
                    break;
                case NotifyButton.Cancel:
                    this.btnCancel.Visibility = Visibility.Visible;
                    this.btnOK.Visibility = Visibility.Collapsed;
                    break;
                case NotifyButton.OkAndCancel:
                    this.btnOK.Visibility = Visibility.Visible;
                    this.btnCancel.Visibility = Visibility.Visible;
                    break;
            }

            switch (type)
            {
                case NotifyType.StatusMessage:
                    mainGrid.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    break;
                case NotifyType.ErrorMessage:
                    mainGrid.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;
            }

            txtStatusBlock.Text = title + Environment.NewLine + Environment.NewLine + message;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NotifyManager.GetInstance().Close(NotifyResult.Cancel);
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            NotifyManager.GetInstance().Close(NotifyResult.Ok);
        }
    }


}
