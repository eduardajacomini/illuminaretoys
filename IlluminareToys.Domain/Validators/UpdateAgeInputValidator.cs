using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs.Ages;

namespace IlluminareToys.Domain.Validators
{
    public class UpdateAgeInputValidator : AbstractValidator<UpdateAgeInput>
    {
        public UpdateAgeInputValidator()
        {
            RuleFor(x => x.Quantity)
               .NotEmpty()
               .WithMessage(ValidationMessages.ValueInvalid);
        }
    }
}
