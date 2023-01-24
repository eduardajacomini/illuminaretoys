using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs.Products;

namespace IlluminareToys.Domain.Validators
{
    public class AssociateGroupsToProductInputValidator : AbstractValidator<AssociateGroupsToProductInput>
    {
        public AssociateGroupsToProductInputValidator()
        {
            RuleFor(x => x.ProductGroups.Count())
              .GreaterThan(0)
              .WithMessage(ValidationMessages.GroupsInvalid);
        }
    }
}
