using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs.Group
{
    public class UpdateGroupOutput : BaseOutput
    {
        public UpdateGroupOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public UpdateGroupOutput(ValidationFailure error) : base(error) { }
    }
}
