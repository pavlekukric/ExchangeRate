using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace ExchangeRate.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValdationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
