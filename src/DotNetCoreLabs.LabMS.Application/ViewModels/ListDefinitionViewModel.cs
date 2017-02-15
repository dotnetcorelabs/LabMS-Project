using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Application.ViewModels
{
    public class ListDefinitionViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Uri { get; set; }

        public string Description { get; set; }
    }
}
