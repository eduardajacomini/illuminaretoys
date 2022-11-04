using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs
{
    public class GetProductOutput : BaseOutput
    {
        public GetProductOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public string BlingId { get; private set; }

        public string Code { get; private set; }

        public string Description { get; private set; }

        public string Price { get; private set; }

        public string PriceCost { get; private set; }

        public string ImageUrl { get; private set; }

        public string CategoryId { get; private set; }

        public string CategoryDescription { get; private set; }

        public string Unity { get; private set; }

        public string State { get; private set; }

        public string BlingCreatedAt { get; private set; }

        public string BlingUpdatedAt { get; private set; }
    }
}
