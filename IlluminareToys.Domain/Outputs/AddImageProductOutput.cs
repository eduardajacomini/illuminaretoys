using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs
{
    public class AddImageProductOutput : BaseOutput
    {

        public AddImageProductOutput(ValidationFailure error) : base(error) { }
        public AddImageProductOutput(List<ValidationFailure> errors = null) : base(errors) { }
    }
}
