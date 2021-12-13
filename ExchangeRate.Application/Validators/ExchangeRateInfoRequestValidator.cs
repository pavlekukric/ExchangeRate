using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExchangeRate.Application.Requests;
using FluentValidation;

namespace ExchangeRate.Application.Validators
{
    public class ExchangeRateInfoRequestValidator: AbstractValidator<ExchangeRateInfoRequest>
    {
        //TODO additional validations needed
        public ExchangeRateInfoRequestValidator()
        {
            RuleFor(p => p.BaseCurrency)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.TargetCurrency)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleForEach(p => p.Dates)
                .NotEmpty()
                .NotNull()
                .WithMessage("You must enter at least one date.");

            RuleForEach(p => p.Dates)
                .LessThan(DateTime.Now)
                .WithMessage($"Dates cannot be in the future.");
        }
    }
}
