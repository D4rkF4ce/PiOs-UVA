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

namespace HiGHTECHNiX.Pi.OperatingSystem
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            OsEngine.OsEngine.CheckBasicData();

            ViewHandler.GetInstance().SetMainWindow(this);
            ViewHandler.GetInstance().Switch(PageType.Login);

            PiWallpaperStage.Child = new PiWallpaper();

            PiSideBarStage.Visibility = Visibility.Collapsed;

            PiTaskbarStage.Visibility = Visibility.Collapsed;
            PiTaskbarStage.Child = new Controls.Desktop.PiTaskbar(this);

            PiFlowMenuStage.Visibility = Visibility.Collapsed;
            PiFlowMenuStage.Child = new Controls.Desktop.PiFlowMenu();           
        }

        public void Switch(PageType page, object model = null)
        {            
            try
            {
                PiFlowMenuStage.Visibility = Visibility.Collapsed;

                if (page == PageType.Login)
                {
                    PiLockScreenStage.Visibility = Visibility.Visible;
                    PiDesktopStage.Visibility = Visibility.Collapsed;
                    PiTaskbarStage.Visibility = Visibility.Collapsed;
                }

                switch (page)
                {
                    case PageType.Login:
                        PiLockScreenStage.Child = new PiOs.PiLogin.PiLogin();
                        break;
                    case PageType.Desktop:
                        PiDesktopStage.Child = new PiOs.PiDesktop.PiDesktop();
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
                
                if (page != PageType.Login && PiLockScreenStage.Visibility == Visibility.Visible)
                {                    
                    PiDesktopStage.Visibility = Visibility.Visible;
                    PiTaskbarStage.Visibility = Visibility.Visible;
                    PiLockScreenStage.Visibility = Visibility.Collapsed;
                }                
            }
            catch (Exception ex)
            {

            }            
        }

        private void Page_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (PiLockScreenStage.Visibility != Visibility.Visible)
            {
#if DEBUG
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    if (e.Key == Windows.System.VirtualKey.F10)
                    {
                        TogglePiFlowMenu();
                    }
                }            
#else
                if (e.Key == Windows.System.VirtualKey.LeftWindows || e.Key == Windows.System.VirtualKey.RightWindows)
                {
                    TogglePiFlowMenu();
                }
#endif
            }
        }

        public PiFlowMenu GetFlowMenu()
        {
            return PiFlowMenuStage.Child as PiFlowMenu;
        }

        public void TogglePiFlowMenu()
        {
            if (PiFlowMenuStage.Visibility == Visibility.Collapsed)
                PiFlowMenuStage.Visibility = Visibility.Visible;
            else
                PiFlowMenuStage.Visibility = Visibility.Collapsed;
        }

    } 
}
