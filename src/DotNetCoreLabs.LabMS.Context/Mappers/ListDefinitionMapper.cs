using DapperExtensions.Mapper;
using DotNetCoreLabs.LabMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Context.Mappers
{
    public class ListDefinitionMapper : ClassMapper<ListDefinition>
    {
        public ListDefinitionMapper()
        {
            Table("ListDefinition");

            Map(p => p.Id).Column("Id").Key(KeyType.Guid);
            //Map(p => p.Title).Column("Title");
            //Map(p => p.Uri).Column("Uri");
            //Map(p => p.Description).Column("Description");
            AutoMap();
        }
    }
}
