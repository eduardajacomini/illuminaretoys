using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs.Tags;

namespace IlluminareToys.Domain.Validators
{
    public class UpdateTagInputValidator : AbstractValidator<UpdateTagInput>
    {
        public UpdateTagInputValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(ValidationMessages.DescriptionInvalid);

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(ValidationMessages.IdInvalid);
        }
    }
}
