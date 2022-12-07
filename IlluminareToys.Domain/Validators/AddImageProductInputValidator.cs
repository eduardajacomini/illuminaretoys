using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs;

namespace IlluminareToys.Domain.Validators
{
    public class AddImageProductInputValidator : AbstractValidator<AddImageProductInput>
    {
        public AddImageProductInputValidator()
        {
            RuleFor(x => x.ProductId)
               .NotEmpty()
               .WithMessage(ValidationMessages.IdInvalid);

            RuleFor(x => x.Image)
               .NotNull()
               .WithMessage(ValidationMessages.ImageInvalid);

            RuleFor(x => x.Image.Length)
               .GreaterThan(0)
               .WithMessage(ValidationMessages.ImageRequired);
        }
    }
}
