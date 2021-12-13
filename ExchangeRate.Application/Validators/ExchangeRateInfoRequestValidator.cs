using System;
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
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage($"Dates cannot be in the future.");

            RuleForEach(p => p.Dates)
                .GreaterThan(new DateTime(1999,1,1))
                .WithMessage($"Historical rates are available for most currencies back to the year of 1999. You cannot pass date older then this.");
        }
    }
}
