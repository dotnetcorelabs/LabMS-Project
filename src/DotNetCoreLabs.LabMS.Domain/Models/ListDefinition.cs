using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Domain.Models
{
    public class ListDefinition : Entity
    {
        public string Title { get; set; }

        public string Uri { get; set; }

        public string Description { get; set; }

        public ListDefinition(Guid id, string title, string uri, string description)
        {
            Id = id;
            Title = title;
            Uri = uri;
            Description = description;
        }

        public ListDefinition()
        {

        }
    }
}
