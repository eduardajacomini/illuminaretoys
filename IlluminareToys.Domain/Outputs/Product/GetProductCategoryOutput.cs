namespace IlluminareToys.Domain.Outputs.Product
{
    public record GetProductCategoryOutput
    {
        public string Id { get; set; }

        public string Description { get; set; }
    }
}
