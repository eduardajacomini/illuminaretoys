using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs.Age
{
    public class DeleteAgeOutput : BaseOutput
    {
        public DeleteAgeOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public DeleteAgeOutput(ValidationFailure error) : base(error) { }
    }
}
