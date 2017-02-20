using AutoMapper;
using DotNetCoreLabs.LabMS.Application.ViewModels;
using DotNetCoreLabs.LabMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ListDefinitionViewModel, ListDefinition>()
                .ConstructUsing(c => new ListDefinition(c.Id, c.Title, c.Uri, c.Description));
        }
    }
}
