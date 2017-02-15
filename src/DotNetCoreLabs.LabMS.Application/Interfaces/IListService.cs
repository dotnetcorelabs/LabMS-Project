using DotNetCoreLabs.LabMS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Application.Interfaces
{
    public interface IListService
    {
        Task CreateAsync(ListDefinitionViewModel dataModel);

        Task<ListDefinitionViewModel[]> GetAllAsync();

        Task<ListDefinitionViewModel> GetAsync(string title);

        Task<ListDefinitionViewModel> GetByIdAsync(string id);
    }
}
