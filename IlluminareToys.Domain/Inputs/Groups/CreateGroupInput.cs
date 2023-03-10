using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Inputs.Groups
{
    public record CreateGroupInput
    {
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}
