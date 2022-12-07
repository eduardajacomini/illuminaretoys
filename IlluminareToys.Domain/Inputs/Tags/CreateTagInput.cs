using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Inputs.Tags
{
    public class CreateTagInput
    {
        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}
