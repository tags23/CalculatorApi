using Calculator.Api.Entities.Requests;
using FluentValidation;

namespace Calculator.Api.Validators
{
    public class SmallestOrBiggestDigitRequesttValidator : AbstractValidator<SmallestOrBiggestDigitRequest>
    {
        public SmallestOrBiggestDigitRequesttValidator()
        {
            RuleFor(x => x.Sequence)
                .NotEmpty()
                .WithMessage("Digit sequence cannot be empty.");

            RuleFor(x => x.Sequence)
                .Must(x => x.Length > 0 && x.Length < 6)
                .WithMessage("Sequence supports a minimum of 1 digit and a maximum of 5 digits.");

            RuleForEach(x => x.Sequence)
                .InclusiveBetween(-9, 9)
                .WithMessage("Sequence can contain only valid digits from -9 to 9.");

            RuleFor(x => x.ReturnDigit)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("The ReturnDigit should be a valid enum ID.");
        }
    }
}
