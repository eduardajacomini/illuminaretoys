using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs
{
    public class AssociateTagsToProductOutput : BaseOutput
    {
        public AssociateTagsToProductOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public AssociateTagsToProductOutput(ValidationFailure error) : base(error) { }
    }
}
