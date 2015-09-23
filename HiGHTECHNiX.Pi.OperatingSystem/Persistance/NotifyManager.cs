using HiGHTECHNiX.Pi.OperatingSystem.Controls.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiGHTECHNiX.Pi.OperatingSystem.Persistance
{
    class NotifyManager
    {
        private readonly static NotifyManager _instance = new NotifyManager();
        public static NotifyManager GetInstance()
        {
            return _instance;
        }

        private static MainPage _root;
        private NotifyResult _result;

        public NotifyResult LastNotifyResult
        {
            get
            {
                return _result;
            }
        }        

        private NotifyManager()
        {
            // only for private using !! 
        }
        
        public void SetMainWindow(MainPage parent)
        {
            _root = parent;
        }

        public void NotifyUser(string title, string message, NotifyType type, NotifyButton button)
        {
            PiNotify.GetInstance().SetNotification(title, message, type, button);
            _root.ShowNotify();
        }
       

        //public async Task<NotifyResult> NotifyUser(string strMessage, NotifyType type, NotifyButton button)
        //{
        //    PiNotify.GetInstance().SetNotification(strMessage, type, button);
        //    _root.ShowNotify();

        //    return await Task.Run(() => _result);
        //}

        public void Close(NotifyResult result)
        {
            _result = result;
            _root.CloseNotify();
        }
    }

    public enum NotifyType
    {
        StatusMessage,
        ErrorMessage
    }

    public enum NotifyButton
    {
        Ok,
        Cancel,
        OkAndCancel
    }

    public enum NotifyResult
    {
        Ok,
        Cancel
    }
}
