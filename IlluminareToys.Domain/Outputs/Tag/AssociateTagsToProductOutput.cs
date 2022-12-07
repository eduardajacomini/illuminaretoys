using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs.Tag
{
    public class AssociateTagsToProductOutput : BaseOutput
    {
        public AssociateTagsToProductOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public AssociateTagsToProductOutput(ValidationFailure error) : base(error) { }
    }
}
