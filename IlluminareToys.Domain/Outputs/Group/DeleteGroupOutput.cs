using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs.Group
{
    public class DeleteGroupOutput : BaseOutput
    {
        public DeleteGroupOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public DeleteGroupOutput(ValidationFailure error) : base(error) { }
    }
}
