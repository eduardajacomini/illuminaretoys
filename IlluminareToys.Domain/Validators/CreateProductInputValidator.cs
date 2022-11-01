using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs;

namespace IlluminareToys.Domain.Validators
{
    public class CreateProductInputValidator : AbstractValidator<CreateTagInput>
    {
        public CreateProductInputValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(ValidationMessages.DescriptionInvalid);
        }
    }
}
