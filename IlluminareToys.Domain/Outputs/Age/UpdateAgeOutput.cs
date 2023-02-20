using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs.Age
{
    public class UpdateAgeOutput : BaseOutput
    {
        public UpdateAgeOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public UpdateAgeOutput(ValidationFailure error) : base(error) { }
    }
}
