using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Data.SqlClient;

namespace FirstMVCApp.Models
{
    public class SqlHelper
    {
        public static SqlConnection CreateConnection()
        {
            var connString = @"server=200411LTP2784\SQLEXPRESS;database=testdb;
            integrated security = true; Encrypt = false;";
            SqlConnection sqlcn = new SqlConnection(connString);
            return sqlcn;
        }
    }
}
