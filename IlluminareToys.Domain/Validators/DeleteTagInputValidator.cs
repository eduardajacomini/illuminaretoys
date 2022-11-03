using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs;

namespace IlluminareToys.Domain.Validators
{
    public class DeleteTagInputValidator : AbstractValidator<DeleteTagInput>
    {
        public DeleteTagInputValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(ValidationMessages.IdInvalid);
        }
    }
}
