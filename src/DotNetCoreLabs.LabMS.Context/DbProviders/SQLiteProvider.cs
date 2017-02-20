using DapperExtensions.Sql;
using DotNetCoreLabs.LabMS.Context.Interfaces;
using DotNetCoreLabs.LabMS.Context.Mappers;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Context.DbProviders
{
    public class SQLiteProvider : IDatabaseProvider
    {
        private static bool _started;

        private readonly string _connectionString;

        public SQLiteProvider(string connectionString)
        {
            _connectionString = connectionString;
            EnsureDatabase();
        }

        public DbConnection CreateDbConnection() => new SqliteConnection(_connectionString);

        public void EnsureDatabase()
        {
            if (!_started)
            {
                if (!File.Exists(_connectionString))
                {
                    using (var db = CreateDbConnection())
                    {
                        var cmd = db.CreateCommand();
                        cmd.CommandText = CreateSQL("listdefinition");
                        if (db.State != System.Data.ConnectionState.Open)
                        {
                            db.Open();
                        }
                        cmd.ExecuteNonQuery();
                        if (db.State != System.Data.ConnectionState.Closed)
                        {
                            db.Close();
                        }
                    }
                }
            }
            _started = true;
        }

        public string CreateSQL(string table)
        {
            return File.ReadAllText(Path.Combine(@"C:\temp\dbb", $"tbl_{table}.sql"));
        }
    }
}
