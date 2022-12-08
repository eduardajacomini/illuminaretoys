using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs.Tag
{
    public class GetTagGroupOutput : BaseOutput
    {
        public GetTagGroupOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public Guid Id { get; set; }

        public Guid TagId { get; set; }

        public Guid GroupId { get; set; }

        public string Age { get; set; }
    }
}
