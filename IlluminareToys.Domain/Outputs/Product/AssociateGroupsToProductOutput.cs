using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs.Product
{
    public class AssociateGroupsToProductOutput : BaseOutput
    {
        public AssociateGroupsToProductOutput()
        {

        }
        public AssociateGroupsToProductOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }
        public AssociateGroupsToProductOutput(ValidationFailure error = null) : base(error) { }
    }
}
