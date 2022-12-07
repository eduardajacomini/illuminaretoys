using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs.Tags;

namespace IlluminareToys.Domain.Validators
{
    public class CreateTagGroupInputValidator : AbstractValidator<CreateTagGroupInput>
    {
        public CreateTagGroupInputValidator()
        {
            RuleFor(x => x.TagsGroups.Count())
                .GreaterThan(0)
                .WithMessage(ValidationMessages.TagsGroups);
        }
    }
}
