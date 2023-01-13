using FluentValidation.Results;
using IlluminareToys.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Outputs.Age
{
    public class GetAgeOutput : BaseOutput
    {
        public GetAgeOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Valor")]
        public int Quantity { get; set; }

        [Display(Name = "Tipo")]
        public AgeType Type { get; set; }

        [Display(Name = "Criado em")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Atualizado em")]
        public DateTime UpdatedAt { get; set; }

        [Display(Name = "Idade")]
        public string QuantityNormalized => $"{Quantity} {GetTypeNormalized(Quantity)}";

        private string GetTypeNormalized(int quantity)
        {
            return Type switch
            {
                AgeType.YEARS => quantity > 1 ? "anos" : "ano",
                AgeType.MONTHS => quantity > 1 ? "meses" : "mês",
                _ => "default"
            };
        }
    }
}
