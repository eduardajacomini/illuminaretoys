using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs.Products;

namespace IlluminareToys.Domain.Validators
{
    public class AssociateAgesToProductInputValidator : AbstractValidator<AssociateAgesToProductInput>
    {
        public AssociateAgesToProductInputValidator()
        {
            RuleFor(x => x.ProductId)
               .NotEmpty()
               .WithMessage(ValidationMessages.ProductIdInvalid);

            RuleFor(x => x.Ages.Count())
                .GreaterThan(0)
                .WithMessage(ValidationMessages.AgesInvalid);
        }
    }
}
