using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Domain.Validations
{
    public class ValidationError
    {
        public string Message { get; set; }
        public ValidationError(string message)
        {
            Message = message;
        }
    }
}
