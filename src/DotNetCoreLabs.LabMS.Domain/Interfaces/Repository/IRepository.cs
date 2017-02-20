using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity data);

        Task<IEnumerable<TEntity>> FindAsync(object where = null);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task RemoveAsync(TEntity data);

        Task UpdateAsync(TEntity data);
    }
}
