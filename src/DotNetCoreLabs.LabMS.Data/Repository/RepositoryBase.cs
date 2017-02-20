using DotNetCoreLabs.LabMS.Context;
using DotNetCoreLabs.LabMS.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreLabs.LabMS.Context.Interfaces;
using System.Diagnostics;

namespace DotNetCoreLabs.LabMS.Data.Repository
{
    public class RepositoryBase<TEntity> : DapperRepositoryBase, IRepository<TEntity>
        where TEntity : class
    {
        public RepositoryBase(IDataContext context) : base(context)
        {
        }

        public async Task AddAsync(TEntity data)
        {
            await base.AddAsync(data);
        }

        public Task<IEnumerable<TEntity>> FindAsync(object where = null)
        {
            return base.GetByAsync<TEntity>(where);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return base.GetAllAsync<TEntity>();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return base.GetByIdAsync<TEntity>(id);
        }

        public Task RemoveAsync(TEntity data)
        {
            return base.RemoveAsync(data);
        }

        public Task UpdateAsync(TEntity data)
        {
            return base.UpdateAsync(data);
        }

        public bool SaveChanges()
        {
            try
            {
                Commit();
            }
            catch (Exception ex)
            {
                Rollback();
                Trace.TraceError($"Error executing transaction. {ex.Message}");
                throw;
            }

            return false;
        }
    }
}
