using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs
{
    public abstract class BaseOutput
    {
        public BaseOutput(IEnumerable<ValidationFailure> errors = null)
        {
            Errors = errors ?? new List<ValidationFailure>();
        }

        public BaseOutput(ValidationFailure error)
        {
            Errors = new List<ValidationFailure> { error };
        }

        public BaseOutput()
        {

        }

        public IEnumerable<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();

        public bool IsValid => !Errors.Any();
    }
}
