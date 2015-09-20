using HiGHTECHNiX.Pi.SQLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace HiGHTECHNiX.Pi.OsEngine
{
    public sealed class OsManager
    {
        private static UserGateway _userGateway = new UserGateway();
        private readonly static OsManager _instance = new OsManager();
        public static OsManager GetInstance()
        {
            return _instance;
        }

        private OsManager()
        {
            // only for private using !! 
        }       

        public void CheckBasicData()
        {
            if (!_userGateway.BasicDataAvailable())
            {
                _userGateway.CreateBasicData();
            }            
        }

        public string GetOsVersion()
        {
            string version = "";

            version = string.Format("Version: {0}.{1}.{2}.{3}",
                    Package.Current.Id.Version.Major,
                    Package.Current.Id.Version.Minor,
                    Package.Current.Id.Version.Build,
                    Package.Current.Id.Version.Revision);
            return version;
        }




    }
}
