using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HiGHTECHNiX.Pi.OsEngine
{
    public static class TaskbarEngine
    {       
        public static string GetDateTimeToString()
        {
            return OsEngine.SystemDateTime.ToString().Substring(0, OsEngine.SystemDateTime.ToString().Length - 3);
        }

    }
}
