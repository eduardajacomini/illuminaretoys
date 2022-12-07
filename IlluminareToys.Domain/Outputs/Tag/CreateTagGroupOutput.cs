using FluentValidation.Results;

namespace IlluminareToys.Domain.Outputs.Tag
{
    public class CreateTagGroupOutput : BaseOutput
    {
        public CreateTagGroupOutput(List<ValidationFailure> errors = null) : base(errors) { }
    }
}
