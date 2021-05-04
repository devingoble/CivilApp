using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Configuration
{
    public static class ConnectionStringBuilder
    {
        public static string BuildSQLConnectionString(string server, string database, string user, string password)
        {
            return $"Data Source={server};Initial Catalog={database};User={user};Password={password};MultipleActiveResultSets=True";
        }
    }
}
