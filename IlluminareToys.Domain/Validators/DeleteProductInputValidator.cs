using FluentValidation;
using IlluminareToys.Domain.Constants;
using IlluminareToys.Domain.Inputs.Products;

namespace IlluminareToys.Domain.Validators
{
    public class DeleteProductInputValidator : AbstractValidator<DeleteProductInput>
    {
        public DeleteProductInputValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(ValidationMessages.IdInvalid);
        }
    }
}
