using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace HiGHTECHNiX.Pi.OperatingSystem.Persistance
{
    public sealed class ViewHandler
    {
        private readonly static ViewHandler _instance = new ViewHandler();
        public static ViewHandler GetInstance()
        {
            return _instance;
        }

        private static MainPage _mainView;

        private ViewHandler()
        {
            // only for private using !! 
        }

        public void Switch(PageType page, object model = null)
        {
            _mainView.Switch(page, model);
        }

        public void SetMainWindow(MainPage MainView)
        {
            _mainView = MainView;
        }

        
    }

    public enum PageType
    {
        Login,
        Desktop,
        WebBrowser,
        Weather,
        System
    }

}
