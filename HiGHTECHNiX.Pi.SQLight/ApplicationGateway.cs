using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiGHTECHNiX.Pi.SQLight
{
    public class ApplicationGateway
    {
        private string _path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "application.db");
        private SQLite.Net.SQLiteConnection _conn;


        public void CreateDatabase()
        {        
            _conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), _path);

        }
    }
}
