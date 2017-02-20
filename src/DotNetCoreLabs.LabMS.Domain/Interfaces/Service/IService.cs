using DotNetCoreLabs.LabMS.Domain.Interfaces.Validations;
using DotNetCoreLabs.LabMS.Domain.Models;
using DotNetCoreLabs.LabMS.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Domain.Interfaces.Service
{
    public interface IService<TEntity>
        where TEntity : Entity
    {
        Task<ValidationResult> Add(TEntity entity);
        Task<ValidationResult> Update(TEntity entity);
        Task<ValidationResult> Remove(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetBy(object @where = null);
    }
}
