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

namespace HiGHTECHNiX.Pi.OperatingSystem.Controls.Sidebar
{
    public sealed partial class PiMediaPlayer : UserControl
    {
        public PiMediaPlayer()
        {
            this.InitializeComponent();
            IsPlaying(false);
            btnPlay.IsEnabled = true;
        }

        private void IsPlaying(bool flag)
        {
            if (!flag)
            {
                btnPause.Visibility = Visibility.Collapsed;
                btnPlay.Visibility = Visibility.Visible;
            }
            else
            {
                btnPause.Visibility = Visibility.Visible;
                btnPlay.Visibility = Visibility.Collapsed;
            }

            //btnPlay.IsEnabled = flag;
            //btnStop.IsEnabled = flag;
            btnMoveBack.IsEnabled = flag;
            btnMoveForward.IsEnabled = flag;
        }

        private void btnClose_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ViewManager.GetInstance().ToggleWidget(Widget.MediaPlayer);
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            IsPlaying(true);
            MediaPlayer.Source = new Uri("ms-appx:///Assets/Videos/promo_windows_10_features.mp4");           
            MediaPlayer.Play();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Pause();            
            IsPlaying(false);          
        }

        private void btnMoveBack_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Position -= TimeSpan.FromSeconds(10);
        }

        private void btnMoveForward_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Position += TimeSpan.FromSeconds(10);
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Pause();
            IsPlaying(false);
        }
    }
}
