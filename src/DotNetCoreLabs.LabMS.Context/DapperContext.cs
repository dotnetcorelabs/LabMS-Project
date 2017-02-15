using DotNetCoreLabs.LabMS.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Context
{
    public class DapperContext : IDataContext
    {
        private IDbConnection _connection;
        private readonly IDatabaseProvider _databaseProvider;

        public DapperContext(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }


        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = _databaseProvider.CreateDbConnection();
                }

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}
