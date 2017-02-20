using DotNetCoreLabs.LabMS.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreLabs.LabMS.Domain.Validations;
using DotNetCoreLabs.LabMS.Domain.Interfaces.Repository;
using DotNetCoreLabs.LabMS.Domain.Interfaces.Validations;
using DotNetCoreLabs.LabMS.Domain.Models;

namespace DotNetCoreLabs.LabMS.Domain.Services
{
    public abstract class ServiceBase<TEntity> : IService<TEntity>
        where TEntity : Entity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly ValidationResult _validationResult;

        public ServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository;
            _validationResult = new ValidationResult();
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }

        public async Task<ValidationResult> Add(TEntity entity)
        {
            if (!_validationResult.IsValid)
                return ValidationResult;

            if (!entity.IsValid())
                return entity.ValidationResult;

            try
            {
                await _repository.AddAsync(entity);
            }
            catch (Exception)
            {
                _validationResult.Add($"A Entidade que você está tentando gravar está nula, por favor tente novamente! {entity.GetType().Name} - Adicionar");
            }

            return _validationResult;
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            return _repository.GetAllAsync();
        }

        public Task<IEnumerable<TEntity>> GetBy(object @where = null)
        {
            return _repository.FindAsync(@where);
        }

        public Task<TEntity> GetById(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task<ValidationResult> Remove(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            try
            {
                await _repository.RemoveAsync(entity);
            }
            catch (Exception)
            {
                _validationResult.Add($"A Entidade que você está tentando deletar está nula, por favor tente novamente! Nome: {entity.GetType().Name} Deletar");
            }

            return _validationResult;
        }

        public async Task<ValidationResult> Update(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            if (!entity.IsValid())
                return entity.ValidationResult;

            try
            {
                await _repository.UpdateAsync(entity);
            }
            catch (Exception)
            {
                _validationResult.Add($"A Entidade que você está tentando atualizar está nula, por favor tente novamente! Nome: {entity.GetType().Name} Atualizar");
            }

            return _validationResult;
        }
    }
}
