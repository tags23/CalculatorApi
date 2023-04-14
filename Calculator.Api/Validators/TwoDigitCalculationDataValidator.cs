using Calculator.Api.Entities.Requests;
using Calculator.Api.Enums;
using FluentValidation;

namespace Calculator.Api.Validators
{
    public class TwoDigitCalculationDataValidator : AbstractValidator<TwoDigitCalculationRequest>
    {
        public TwoDigitCalculationDataValidator()
        {
            RuleFor(x => x.FirstDigit)
                .NotNull()
                .InclusiveBetween(-9, 9)
                .WithMessage("First digit must be a valid digit from -9 to 9.");

            RuleFor(x => x.SecondDigit)
                .NotNull()
                .InclusiveBetween(-9, 9)
                .WithMessage("Second digit must be a valid digit from -9 to 9.");

            RuleFor(x => x.SecondDigit)
                .NotEqual(0)
                .When(x => x.Operator == Operator.Division)
                .WithMessage("Division by zero is not allowed.");

            RuleFor(x => x.Operator)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Operator should be a valid enum ID.");
        }
    }
}
