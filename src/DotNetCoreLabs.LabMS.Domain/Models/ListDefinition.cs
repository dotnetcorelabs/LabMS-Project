using DotNetCoreLabs.LabMS.Domain.Interfaces.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreLabs.LabMS.Domain.Validations;

namespace DotNetCoreLabs.LabMS.Domain.Models
{
    public class ListDefinition : Entity
    {
        public string Title { get; set; }

        public string Uri { get; set; }

        public string Description { get; set; }

        public ListDefinition(int id, string title, string uri, string description)
        {
            Id = id;
            Title = title;
            Uri = uri;
            Description = description;
        }

        public ListDefinition()
        {

        }

        //TODO implement validation here
        public override bool IsValid()
        {
            return base.ValidationResult.IsValid;
        }
    }
}
