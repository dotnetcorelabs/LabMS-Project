using DotNetCoreLabs.LabMS.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Domain.Interfaces.Validations
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid();
    }
}
