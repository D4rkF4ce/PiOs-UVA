using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace HiGHTECHNiX.Pi.OperatingSystem.Persistance
{
    public sealed class ViewManager
    {
        private readonly static ViewManager _instance = new ViewManager();
        public static ViewManager GetInstance()
        {
            return _instance;
        }

        private static MainPage _root;

        private ViewManager()
        {
            // only for private using !! 
        }

        public void Switch(PageType page, object model = null)
        {
            _root.Switch(page, model);
        }

        public void SetMainWindow(MainPage parent)
        {
            _root = parent;
        }

        public void TogglePiFlowMenu()
        {
            _root.TogglePiFlowMenu();
        }

        public void ToggleWidget(Widget widget, object model = null)
        {
            _root.ToggleWidget(widget, model);
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

    public enum Widget
    {
        MediaPlayer
    }

}
