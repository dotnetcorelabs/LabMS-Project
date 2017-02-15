using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Data
{
    public class DbOptions
    {
        public string ConnectionString { get; set; }

        public string DatabaseProvider { get; set; }
    }

    public class DatabaseProviderString
    {
        public const string SQLiteProvider = "SQLite";

        public const string MSSqlServerProvider = "MSSqlServer";
    }
}
