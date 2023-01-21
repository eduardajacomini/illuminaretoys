namespace IlluminareToys.Domain.Inputs.Products
{
    public record AssociateGroupsToProductInput
    {
        public IEnumerable<Guid> GroupIds { get; set; }

        public Guid ProductId { get; set; }
    }
}
