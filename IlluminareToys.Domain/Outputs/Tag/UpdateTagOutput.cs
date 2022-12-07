using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Outputs.Tag
{
    public class UpdateTagOutput : BaseOutput
    {
        public UpdateTagOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public UpdateTagOutput(ValidationFailure error) : base(error) { }

        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Criado em")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Atualizado em")]
        public DateTime UpdatedAt { get; set; }
    }
}
