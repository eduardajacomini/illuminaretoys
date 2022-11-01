using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs;

namespace IlluminareToys.Domain.Validators
{
    public class CreateTagInputValidator : AbstractValidator<CreateTagInput>
    {
        public CreateTagInputValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(ValidationMessages.DescriptionInvalid);
        }
    }
}
