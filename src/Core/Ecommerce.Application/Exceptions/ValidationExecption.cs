using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Exceptions
{
    public class ValidationExecption : ApplicationException
    {
        public List<string> Errors { get; set; }
        public ValidationExecption(ValidationResult validationResult)
        {
            foreach (var err in validationResult.Errors)
            {
                Errors.Add(err.ErrorMessage);
            }
        }
    }
}
