using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs
{
    public class DeleteTagOutput : BaseOutput
    {
        public DeleteTagOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public DeleteTagOutput(ValidationFailure error) : base(error) { }
    }
}
