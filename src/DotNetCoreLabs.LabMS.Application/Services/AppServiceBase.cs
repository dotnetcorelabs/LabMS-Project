using DotNetCoreLabs.LabMS.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Application.Services
{
    public abstract class AppServiceBase
    {
        public AppServiceBase()
        {
            ValidationResult = new ValidationResult();
        }
        protected ValidationResult ValidationResult { get; private set; }
    }
}
