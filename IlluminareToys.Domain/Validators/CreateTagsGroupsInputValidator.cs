using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs.Tags;

namespace IlluminareToys.Domain.Validators
{
    public class CreateTagsGroupsInputValidator : AbstractValidator<CreateTagsGroupsInput>
    {
        public CreateTagsGroupsInputValidator()
        {
            RuleFor(x => x.TagsGroups.Count())
                .GreaterThan(0)
                .WithMessage(ValidationMessages.TagsGroupsInvalid);
        }
    }
}
