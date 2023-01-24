namespace IlluminareToys.Domain.Inputs.Products
{
    public record AssociateGroupsToProductInput
    {
        public IEnumerable<AssociateGroupsToProductInputItem> ProductGroups { get; set; } = new List<AssociateGroupsToProductInputItem>();
    }

    public record AssociateGroupsToProductInputItem
    {
        public Guid ProductId { get; set; }

        public Guid GroupId { get; set; }

        public IEnumerable<Guid> AgeIds { get; set; } = new List<Guid>();
    }
}
