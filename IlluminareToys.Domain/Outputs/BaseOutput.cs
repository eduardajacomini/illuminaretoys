using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs
{
    public abstract class BaseOutput
    {
        public BaseOutput(IEnumerable<ValidationFailure> errors = null)
        {
            Errors = errors ?? new List<ValidationFailure>();
        }

        public IEnumerable<ValidationFailure> Errors { get; set; }

        public bool IsValid => Errors.Any();
    }
}
