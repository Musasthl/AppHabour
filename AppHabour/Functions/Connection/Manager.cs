using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace AppHabour.Functions.Connection
{
    public class Manager
    {
        public string GetConnectionString()
        {
            var uriString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLSERVER_URI"].ConnectionString;
            var uri = new Uri(uriString);
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = uri.Host,
                InitialCatalog = uri.AbsolutePath.Trim('/'),
                UserID = uri.UserInfo.Split(':').First(),
                Password = uri.UserInfo.Split(':').Last(),
            }.ConnectionString;

            return connectionString.ToString();
        }
    }
}