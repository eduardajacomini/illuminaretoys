using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs
{
    public abstract class BaseOutput
    {
        public BaseOutput(List<ValidationFailure> errors = null)
        {
            Errors = errors ?? new List<ValidationFailure>();
        }

        public BaseOutput()
        {

        }

        public List<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();

        public bool IsValid => Errors.Any();
    }
}
