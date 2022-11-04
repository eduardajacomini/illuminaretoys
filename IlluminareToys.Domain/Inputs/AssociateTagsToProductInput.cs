namespace IlluminareToys.Domain.Inputs
{
    public record AssociateTagsToProductInput
    {
        public IEnumerable<Guid> TagIds { get; set; } = new List<Guid>();

        public string BlingProductId { get; set; }
    }
}
