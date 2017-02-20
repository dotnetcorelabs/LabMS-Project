using AutoMapper;
using DotNetCoreLabs.LabMS.Application.ViewModels;
using DotNetCoreLabs.LabMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ListDefinition, ListDefinitionViewModel>();
        }
    }
}
