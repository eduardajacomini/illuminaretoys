using FluentValidation.Results;
using IlluminareToys.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Outputs.Age
{
    public class CreateAgeOutput : BaseOutput
    {
        public CreateAgeOutput(List<ValidationFailure> errors = null) : base(errors) { }

        public CreateAgeOutput(ValidationFailure error = null) : base(error) { }

        [Display(Name = "Valor")]
        public int Quantity { get; set; }

        [Display(Name = "Tipo")]
        public AgeType Type { get; set; }

        [Display(Name = "Criado em")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Atualizado em")]
        public DateTime UpdatedAt { get; set; }
    }
}
