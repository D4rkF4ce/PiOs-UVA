using HiGHTECHNiX.Pi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiGHTECHNiX.Pi.SQLight
{
    public class UserGateway
    {
        private static string _dbName = "user.db";
        private static string _path;
        private static SQLite.Net.SQLiteConnection _conn;

        public UserGateway()
        {
            string _path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, _dbName);
            _conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), _path);  
        }

        public bool BasicDataAvailable()
        {
            try
            {
                var query = _conn.Table<User>();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void CreateBasicData()
        {
            _conn.CreateTable<User>();

            var s = _conn.Insert(new User()
            {
                Username = "admin",
                Pwd = "winpi!"
            });
        }       


        public User GetUser(string username, string password)
        {
            var query = _conn.Table<User>().Where(x=>x.Username == username && x.Pwd == password);

            if (query.Any())
            {
                return query.First() as User;
            }
            else
            {
                return null;
            }            
        }
    }
}
