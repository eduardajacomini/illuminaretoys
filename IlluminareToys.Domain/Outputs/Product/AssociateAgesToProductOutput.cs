using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs.Product
{
    public class AssociateAgesToProductOutput : BaseOutput
    {
        public AssociateAgesToProductOutput(IEnumerable<ValidationFailure> errors) : base(errors) { }
    }
}
