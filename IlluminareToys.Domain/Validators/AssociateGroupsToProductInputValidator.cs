using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs.Products;

namespace IlluminareToys.Domain.Validators
{
    public class AssociateGroupsToProductInputValidator : AbstractValidator<AssociateGroupsToProductInput>
    {
        public AssociateGroupsToProductInputValidator()
        {
            RuleFor(x => x.ProductId)
              .NotEmpty()
              .WithMessage(ValidationMessages.ProductIdInvalid);

            RuleFor(x => x.GroupIds.Count())
                .GreaterThan(0)
                .WithMessage(ValidationMessages.GroupsInvalid);
        }
    }
}
