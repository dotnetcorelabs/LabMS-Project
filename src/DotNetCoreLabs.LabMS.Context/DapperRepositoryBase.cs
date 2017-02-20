using DotNetCoreLabs.LabMS.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DapperExtensions;
using System.Data;

namespace DotNetCoreLabs.LabMS.Context
{
    public abstract class DapperRepositoryBase : IDisposable
    {
        private readonly IDataContext _context;

        protected DapperRepositoryBase(IDataContext context)
        {
            _context = context;
        }

        protected virtual Task<dynamic> AddAsync<TEntity>(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
            where TEntity : class
        {
            return entity == null ? null : _context.Connection.InsertAsync(entity, transaction, commandTimeout);
        }

        protected async virtual Task<bool> UpdateAsync<TEntity>(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
            where TEntity : class
        {
            return entity != null && await _context.Connection.UpdateAsync(entity, transaction, commandTimeout);
        }

        protected async virtual Task<bool> RemoveAsync<TEntity>(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
            where TEntity : class
        {
            return entity != null && await _context.Connection.DeleteAsync(entity, transaction, commandTimeout);
        }

        protected virtual Task<TEntity> GetByIdAsync<TEntity>(int id, IDbTransaction transaction = null, int? commandTimeout = null)
            where TEntity : class
        {
            return _context.Connection.GetAsync<TEntity>(id, transaction, commandTimeout);
        }

        protected virtual Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(IDbTransaction transaction = null, int? commandTimeout = null)
            where TEntity : class
        {
            return _context.Connection.GetListAsync<TEntity>(null, null, transaction, commandTimeout);
        }

        protected virtual Task<IEnumerable<TEntity>> GetByAsync<TEntity>(object @where = null, object order = null, IDbTransaction transaction = null, int? commandTimeout = null)
            where TEntity : class
        {
            return _context.Connection.GetListAsync<TEntity>(@where);
        }

        protected void Commit()
        {
            _context.Commit();
        }

        protected void Rollback()
        {
            _context.Rollback();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
