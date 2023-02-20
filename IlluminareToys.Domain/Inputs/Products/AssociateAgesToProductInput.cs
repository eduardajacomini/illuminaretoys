namespace IlluminareToys.Domain.Inputs.Products
{
    public record AssociateAgesToProductInput
    {
        public Guid ProductId { get; set; }

        public IEnumerable<AssociateAgesToProductInputItem> Ages { get; set; } = new List<AssociateAgesToProductInputItem>();
    }

    public record AssociateAgesToProductInputItem
    {
        public Guid AgeId { get; set; }

        public bool IsChecked { get; set; }
    }
}
