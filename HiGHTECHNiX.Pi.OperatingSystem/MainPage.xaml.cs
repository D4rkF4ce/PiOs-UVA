using HiGHTECHNiX.Pi.OperatingSystem.PiOs.PiDesktop;
using HiGHTECHNiX.Pi.OperatingSystem.Apps.System;
using HiGHTECHNiX.Pi.OperatingSystem.Apps.Weather;
using HiGHTECHNiX.Pi.OperatingSystem.Apps.WebBrowser;
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
using HiGHTECHNiX.Pi.OperatingSystem.PiOs.PiLogin;
using Windows.UI.ViewManagement;
using HiGHTECHNiX.Pi.OperatingSystem.Controls.Desktop;
using HiGHTECHNiX.Pi.OsEngine;
using HiGHTECHNiX.Pi.OperatingSystem.Controls.Sidebar;
using HiGHTECHNiX.Pi.OperatingSystem.Controls.Sidebar.MediaPlayer;

namespace HiGHTECHNiX.Pi.OperatingSystem
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeSystem();
        }

        private void InitializeSystem()
        {
            TimeManager.GetInstance().SyncTime();
            SoundManager.GetInstance().SetSoundPlayer(this);
            ViewManager.GetInstance().SetMainWindow(this);
            OsManager.GetInstance().CheckBasicData();
            ViewManager.GetInstance().Switch(PageType.Login);
            PiTaskbar.GetInstance().SetMainWindow(this);
            
            PiWallpaperStage.Child = new PiWallpaper();

            PiLockScreenStage.Child = PiLogin.GetInstance();

            PiWidgetStage.Visibility = Visibility.Collapsed;
            PiWidgetStage.Child = PiMediaPlayerWidget.GetInstance();

            PiTaskbarStage.Visibility = Visibility.Collapsed;
            PiTaskbarStage.Child = PiTaskbar.GetInstance();

            PiFlowMenuStage.Visibility = Visibility.Collapsed;
            PiFlowMenuStage.Child = PiFlowMenu.GetInstance();
        }

        public void Switch(PageType page, object model = null)
        {                    
            try
            {
                PiFlowMenuStage.Visibility = Visibility.Collapsed;
                PiDesktopStage.Child = null;

                switch (page)
                {                    
                    case PageType.Login:
                        ToggleLockscreen(true);
                        break;
                    case PageType.Desktop:
                        PiDesktopStage.Child = PiDesktop.GetInstance();
                        break;
                    case PageType.WebBrowser:
                        PiDesktopStage.Child = new Apps.WebBrowser.PiWebBrowser();
                        break;
                    case PageType.Weather:
                        PiDesktopStage.Child = new Apps.Weather.PiWeather();
                        break;
                    case PageType.System:
                        PiDesktopStage.Child = new Apps.System.PiSystem();
                        break;
                }
                
                if (page != PageType.Login)
                    ToggleLockscreen(false);


            }
            catch (Exception ex)
            {

            }

            GC.Collect();         
        }

        private void Page_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (PiLockScreenStage.Visibility == Visibility.Collapsed)
            {
                if (e.Key == Windows.System.VirtualKey.LeftWindows || e.Key == Windows.System.VirtualKey.RightWindows)
                {
                    TogglePiFlowMenu();
                }

                if ((e.Key == Windows.System.VirtualKey.LeftWindows || e.Key == Windows.System.VirtualKey.RightWindows) && e.Key == Windows.System.VirtualKey.L)
                {
                    ToggleLockscreen(true);
                }
            }
        }

        public void ToggleWidget(Widget widget, object model = null)
        {
            try
            {
                switch (widget)
                {
                    case Widget.MediaPlayer:
                        TogglePiMediaPlayerWidget();
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void TogglePiFlowMenu()
        {
            if (PiFlowMenuStage.Visibility == Visibility.Collapsed)
                PiFlowMenuStage.Visibility = Visibility.Visible;
            else
                PiFlowMenuStage.Visibility = Visibility.Collapsed;
        }

        public void ToggleLockscreen(bool show)
        {
            if (show)
            {
                PiLockScreenStage.Visibility = Visibility.Visible;                
                PiDesktopStage.Visibility = Visibility.Collapsed;
                PiTaskbarStage.Visibility = Visibility.Collapsed;
                SoundManager.GetInstance().PlayLockSound();
            }
            else
            {
                PiDesktopStage.Visibility = Visibility.Visible;
                PiTaskbarStage.Visibility = Visibility.Visible;
                PiLockScreenStage.Visibility = Visibility.Collapsed;
            }
        }

        private void TogglePiMediaPlayerWidget()
        {
            if (PiWidgetStage.Visibility == Visibility.Collapsed)
                PiWidgetStage.Visibility = Visibility.Visible;
            else
                PiWidgetStage.Visibility = Visibility.Collapsed;
        }

        public void PlaySound(string source)
        {
            try
            {
                PiSoundPlayer.Source = new Uri(source);
                PiSoundPlayer.Play();
            }
            catch (Exception ex)
            {

            }
        }

    } 
}
