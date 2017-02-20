using DotNetCoreLabs.LabMS.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;

namespace DotNetCoreLabs.LabMS.Context.DbProviders
{
    public class ContextDatabaseProvider : IDatabaseProvider
    {
        private readonly IDatabaseProvider _dbProvider;

        public ContextDatabaseProvider(DbOptions options)
        {
            _dbProvider = new SQLiteProvider(options.ConnectionString);
        }

        public DbConnection CreateDbConnection()
        {
            return _dbProvider.CreateDbConnection();
        }
    }
}
