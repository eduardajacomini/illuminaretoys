using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Inputs
{
    public record CreateGroupInput
    {
        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}
