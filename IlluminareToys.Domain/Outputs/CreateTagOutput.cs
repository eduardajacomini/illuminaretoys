using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs
{
    public class CreateTagOutput : BaseOutput
    {
        public CreateTagOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public Guid Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
