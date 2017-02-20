using DotNetCoreLabs.LabMS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreLabs.LabMS.Application.ViewModels;
using System.Collections.Concurrent;
using DotNetCoreLabs.LabMS.Domain.Interfaces.Repository;
using DotNetCoreLabs.LabMS.Domain.Interfaces.Service;
using DotNetCoreLabs.LabMS.Data.Interfaces;
using DotNetCoreLabs.LabMS.Domain.Validations;
using AutoMapper;
using DotNetCoreLabs.LabMS.Domain.Models;

namespace DotNetCoreLabs.LabMS.Application.Services
{
    public class ListAppService : AppServiceBase, IListAppService, IDisposable
    {
        private readonly IListDefinitionService _service;
        private readonly IMapper _mapper;

        public ListAppService(IListDefinitionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ValidationResult> CreateAsync(ListDefinitionViewModel dataModel)
        {
            var model = _mapper.Map<ListDefinition>(dataModel);

            ValidationResult.Add(await _service.Add(model));

            //if (ValidationResult.IsValid) _uow.Commit();

            return ValidationResult;
        }

        public async Task<IEnumerable<ListDefinitionViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ListDefinitionViewModel>>(await _service.GetAll());
        }

        public Task<ListDefinitionViewModel> GetAsync(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<ListDefinitionViewModel> GetByIdAsync(int id)
        {
            return _mapper.Map<ListDefinitionViewModel>(await _service.GetById(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
