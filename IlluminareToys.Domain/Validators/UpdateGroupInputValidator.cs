using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs.Groups;

namespace IlluminareToys.Domain.Validators
{
    public class UpdateGroupInputValidator : AbstractValidator<UpdateGroupInput>
    {
        public UpdateGroupInputValidator()
        {
            RuleFor(x => x.Description)
               .NotEmpty()
               .WithMessage(ValidationMessages.DescriptionInvalid);

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(ValidationMessages.NameInvalid);

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(ValidationMessages.IdInvalid);
        }
    }
}
