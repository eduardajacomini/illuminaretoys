using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Inputs.Tags
{
    public class CreateTagInput
    {
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        public IEnumerable<CreateTagGroupInputItem> TagsGroups { get; set; } = new List<CreateTagGroupInputItem>();
    }
}
