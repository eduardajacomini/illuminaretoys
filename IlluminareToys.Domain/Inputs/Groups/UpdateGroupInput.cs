using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Inputs.Groups
{
    public record UpdateGroupInput
    {
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Id")]
        public Guid Id { get; set; }
    }
}
