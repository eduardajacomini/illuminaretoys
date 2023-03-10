using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Inputs.Tags
{
    public class UpdateTagInput
    {
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Id")]
        public Guid Id { get; set; }
    }
}
