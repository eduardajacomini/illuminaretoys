using FluentValidation.Results;
using IlluminareToys.Domain.Outputs.Tag;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace IlluminareToys.Domain.Outputs.Product
{
    public class GetProductOutput : BaseOutput
    {
        public GetProductOutput(IEnumerable<ValidationFailure> errors = null) : base(errors) { }

        public Guid Id { get; private set; }
        public string BlingId { get; private set; }

        [Display(Name = "Código")]
        public string Code { get; private set; }

        [Display(Name = "Descrição")]
        public string Description { get; private set; }

        [Display(Name = "Preço")]
        public string Price { get; private set; }

        [Display(Name = "Preço (R$)")]
        public string PriceFormatted => Convert.ToDecimal(Price.Replace(".", ","), new CultureInfo("pt-BR")).ToString("C", new CultureInfo("pt-BR"));

        [Display(Name = "Preço de Custo")]
        public string PriceCost { get; private set; }

        [Display(Name = "Imagem")]
        public string ImageUrl { get; private set; }

        [Display(Name = "Categoria ID")]
        public string CategoryId { get; private set; }

        [Display(Name = "Categoria")]
        public string CategoryDescription { get; private set; }

        [Display(Name = "Unidade")]
        public string Unity { get; private set; }

        [Display(Name = "Situação")]
        public string State { get; private set; }

        [Display(Name = "Criado no Bling em")]
        public string BlingCreatedAt { get; private set; }

        [Display(Name = "Atualizado no Bling em")]
        public string BlingUpdatedAt { get; private set; }

        [Display(Name = "Sincronizado em")]
        public DateTime? SynchronizedAt { get; private set; }

        public int? CurrentStock { get; set; }

        public IEnumerable<GetTagProductOutput> Tags { get; private set; }
        public IEnumerable<GetProductGroupOutput> Groups { get; private set; }
    }
}
