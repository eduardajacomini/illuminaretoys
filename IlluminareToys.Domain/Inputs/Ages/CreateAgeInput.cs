using IlluminareToys.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Inputs.Ages
{
    public class CreateAgeInput
    {
        [Display(Name = "Valor")]
        public int Quantity { get; set; }

        [Display(Name = "Tipo")]
        public AgeType Type { get; set; }
    }
}
