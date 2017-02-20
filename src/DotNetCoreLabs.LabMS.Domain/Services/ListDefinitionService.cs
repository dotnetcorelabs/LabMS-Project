using DotNetCoreLabs.LabMS.Domain.Interfaces.Service;
using DotNetCoreLabs.LabMS.Domain.Models;
using DotNetCoreLabs.LabMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreLabs.LabMS.Domain.Interfaces.Repository;

namespace DotNetCoreLabs.LabMS.Domain.Services
{
    public class ListDefinitionService : ServiceBase<ListDefinition>, IListDefinitionService
    {
        public ListDefinitionService(IListDefinitionRepository repository) : base(repository)
        {
        }
    }
}
