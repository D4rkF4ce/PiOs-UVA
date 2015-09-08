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
            this.InitializeComponent();

            ViewHandler.GetInstance().SetMainWindow(this);
            ViewHandler.GetInstance().Switch(PageType.Login);   
        }
        
        // Hack: we switch here ;)
        public void Switch(PageType page, object model = null)
        {
            this.PiDesktopStage.Child = null;

            GC.Collect();

            if (page != PageType.Login)
            {
                this.PiTaskbarStage.Child = new Controls.Desktop.PiTaskbar();
            }
            else
                this.PiTaskbarStage.Child = null;

            switch (page)
            {               

                case PageType.Login:
                    this.PiDesktopStage.Child = new PiOs.PiLogin.PiLogin();
                    break;
                case PageType.Desktop:
                    this.PiDesktopStage.Child = new PiOs.PiDesktop.PiDesktop();
                    break;
                case PageType.WebBrowser:
                    this.PiDesktopStage.Child = new Apps.WebBrowser.PiWebBrowser();
                    break;
                case PageType.Weather:
                    this.PiDesktopStage.Child = new Apps.Weather.PiWeather();
                    break;
                case PageType.System:
                    this.PiDesktopStage.Child = new Apps.System.PiSystem();
                    break;
            }
        }
    } 
}
