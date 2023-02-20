using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs.Ages;

namespace IlluminareToys.Domain.Validators
{
    public class CreateAgeInputValidator : AbstractValidator<CreateAgeInput>
    {
        public CreateAgeInputValidator()
        {
            RuleFor(x => x.Quantity)
               .GreaterThan(0)
               .WithMessage(ValidationMessages.ValueInvalid);
        }
    }
}
