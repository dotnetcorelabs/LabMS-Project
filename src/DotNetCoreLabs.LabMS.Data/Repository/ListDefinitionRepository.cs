using DotNetCoreLabs.LabMS.Domain.Interfaces.Repository;
using DotNetCoreLabs.LabMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreLabs.LabMS.Context.Interfaces;

namespace DotNetCoreLabs.LabMS.Data.Repository
{
    public class ListDefinitionRepository : RepositoryBase<ListDefinition>, IListDefinitionRepository
    {
        public ListDefinitionRepository(IDataContext context) : base(context)
        {
        }
    }
}
