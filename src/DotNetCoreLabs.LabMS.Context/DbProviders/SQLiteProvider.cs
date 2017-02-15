using DotNetCoreLabs.LabMS.Context.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
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
        }

        public DbConnection CreateDbConnection() => new SqliteConnection(_connectionString);

        public void EnsureDatabase()
        {
            _started = true;
            //if (!_started)
            //{
            //    if (!File.Exists(_connectionString))
            //    {
            //        using (var conn = CreateConnection())
            //        {
            //            conn.Open();
            //            conn.Execute(
            //                @"create table Customer
            //  (
            //     ID                                  integer identity primary key AUTOINCREMENT,
            //     FirstName                           varchar(100) not null,
            //     LastName                            varchar(100) not null,
            //     DateOfBirth                         datetime not null
            //  )");
            //        }
            //    }
            //}
        }
    }
}
