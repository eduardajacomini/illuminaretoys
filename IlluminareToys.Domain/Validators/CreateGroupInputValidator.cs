using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs.Groups;

namespace IlluminareToys.Domain.Validators
{
    public class CreateGroupInputValidator : AbstractValidator<CreateGroupInput>
    {
        public CreateGroupInputValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(ValidationMessages.DescriptionInvalid);
        }
    }
}
