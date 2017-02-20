using DotNetCoreLabs.LabMS.Application.ViewModels;
using DotNetCoreLabs.LabMS.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Application.Interfaces
{
    public interface IListAppService
    {
        Task<ValidationResult> CreateAsync(ListDefinitionViewModel dataModel);

        Task<IEnumerable<ListDefinitionViewModel>> GetAllAsync();

        Task<ListDefinitionViewModel> GetAsync(string title);

        Task<ListDefinitionViewModel> GetByIdAsync(int id);
    }
}
