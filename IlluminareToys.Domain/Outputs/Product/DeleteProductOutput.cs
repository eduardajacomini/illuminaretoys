using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs.Product
{
    public class DeleteProductOutput : BaseOutput
    {
        public DeleteProductOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public DeleteProductOutput(ValidationFailure error) : base(error) { }
    }
}
