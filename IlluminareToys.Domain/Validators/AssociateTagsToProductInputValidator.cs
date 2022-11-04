using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs;

namespace IlluminareToys.Domain.Validators
{
    public class AssociateTagsToProductInputValidator : AbstractValidator<AssociateTagsToProductInput>
    {
        public AssociateTagsToProductInputValidator()
        {
            RuleForEach(x => x.TagIds)
                .NotEmpty()
                .WithMessage(ValidationMessages.TagIdsInvalid);

            RuleFor(x => x.BlingProductId)
                .NotEmpty()
                .WithMessage(ValidationMessages.BlingProductIdInvalid);
        }
    }
}
