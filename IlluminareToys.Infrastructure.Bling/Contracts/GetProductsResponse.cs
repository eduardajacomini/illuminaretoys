using Newtonsoft.Json;

namespace IlluminareToys.Infrastructure.Bling.Contracts
{
    public class GetProductsResponse
    {
        [JsonProperty("retorno")]
        public Response Response { get; set; } = new Response();
    }

    public partial class Response
    {
        [JsonProperty("produtos")]
        public List<ProductItem> Products { get; set; } = new List<ProductItem>();
    }

    public partial class ProductItem
    {
        [JsonProperty("produto")]
        public ProductData Product { get; set; } = new();
    }

    public partial class ProductData
    {
        [JsonProperty("id")]
        public string BlingId { get; set; }

        [JsonProperty("codigo")]
        public string Code { get; set; }

        [JsonProperty("descricao")]
        public string Description { get; set; }


        [JsonProperty("situacao")]
        public string State { get; set; }

        [JsonProperty("marca")]
        public string Brand { get; set; }

        [JsonProperty("unidade")]
        public string Unity { get; set; }

        [JsonProperty("preco")]
        public string Price { get; set; }

        [JsonProperty("precoCusto")]
        public string PriceCost { get; set; }

        [JsonProperty("dataInclusao")]
        public string BlingCreatedAt { get; set; }

        [JsonProperty("dataAlteracao")]
        public string BlindUpdatedAt { get; set; }

        [JsonProperty("imageThumbnail")]
        public string ImageUrl { get; set; }

        [JsonProperty("categoria")]
        public Category Categoria { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("id")]
        public string CategoryId { get; set; }

        [JsonProperty("descricao")]
        public string CategoryDescription { get; set; }
    }

}
