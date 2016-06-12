using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace refactor_me.Dao
{
    public class Helpers
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DataDirectory}\Database.mdf;Integrated Security=True";

        public static SqlConnection NewConnection()
        {
            var connstr = "";
            if (HttpContext.Current != null)
            {
                connstr = ConnectionString.Replace("{DataDirectory}", HttpContext.Current.Server.MapPath("~/App_Data"));
            }
            else
            {
                var separator = Path.DirectorySeparatorChar;
                var currentPath = AppDomain.CurrentDomain.BaseDirectory;
                var dataPath = currentPath.Substring(0, currentPath.LastIndexOf(separator + "refactor-me.Tests"));
                connstr = ConnectionString.Replace("{DataDirectory}", dataPath + separator + "refactor-me" + separator + "App_Data");
            }
            return new SqlConnection(connstr);
        }

    }
}