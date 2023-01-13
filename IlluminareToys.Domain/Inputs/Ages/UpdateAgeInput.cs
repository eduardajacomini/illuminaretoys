using IlluminareToys.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Inputs.Ages
{
    public class UpdateAgeInput
    {
        [Display(Name = "Tipo")]
        public AgeType Type { get; set; }

        [Display(Name = "Valor")]
        public int Quantity { get; set; }

        [Display(Name = "Id")]
        public Guid Id { get; set; }
    }
}
