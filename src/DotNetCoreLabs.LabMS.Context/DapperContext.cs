using DapperExtensions.Sql;
using DotNetCoreLabs.LabMS.Context.Interfaces;
using DotNetCoreLabs.LabMS.Context.Mappers;
using System.Data;
using System.Reflection;

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

        static DapperContext()
        {
            var assembly = new[] { typeof(ListDefinitionMapper).GetTypeInfo().Assembly };
            DapperExtensions.DapperExtensions.SetMappingAssemblies(assembly);
            DapperExtensions.DapperAsyncExtensions.SetMappingAssemblies(assembly);

            DapperExtensions.DapperExtensions.SqlDialect = new SqliteDialect();
            DapperExtensions.DapperAsyncExtensions.SqlDialect = new SqliteDialect();
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

        private IDbTransaction _transaction;

        public IDbTransaction Transaction
        {
            get
            {
                if (_transaction == null)
                {
                    _transaction = Connection.BeginTransaction();
                }
                return _transaction;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }
    }
}
