using FluentValidation.Results;
using IlluminareToys.Domain.Outputs.Product;
using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Outputs.Group
{
    public class GetGroupOutput : BaseOutput
    {
        public GetGroupOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Criado em")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Atualizado em")]
        public DateTime UpdatedAt { get; set; }

        public IEnumerable<GetProductGroupOutput> ProductsGroups { get; set; }
    }
}
