using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs
{
    public class AddImageProductOutput : BaseOutput
    {
        public AddImageProductOutput(List<ValidationFailure> errors = null) : base(errors) { }
    }
}
