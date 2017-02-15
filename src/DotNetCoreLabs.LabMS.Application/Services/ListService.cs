using DotNetCoreLabs.LabMS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreLabs.LabMS.Application.ViewModels;
using System.Collections.Concurrent;

namespace DotNetCoreLabs.LabMS.Application.Services
{
    public class ListService : IListService
    {
        private static ConcurrentDictionary<string, ListDefinitionViewModel> _listDefinitionColl =
              new ConcurrentDictionary<string, ListDefinitionViewModel>();

        private static List<ListDefinitionViewModel> _list = new List<ListDefinitionViewModel>();

        public Task CreateAsync(ListDefinitionViewModel dataModel)
        {
            _listDefinitionColl.AddOrUpdate(dataModel.Title, dataModel, (k, v) =>
            {
                return v;
            });
            return Task.FromResult(0);
        }

        public Task<ListDefinitionViewModel[]> GetAllAsync()
        {
            return Task.FromResult(_listDefinitionColl.Values.ToArray());
        }

        public Task<ListDefinitionViewModel> GetAsync(string title)
        {
            return Task.FromResult(_listDefinitionColl[title]);
        }

        public Task<ListDefinitionViewModel> GetByIdAsync(string id)
        {
            return Task.FromResult(_listDefinitionColl[id]);
        }
    }
}
