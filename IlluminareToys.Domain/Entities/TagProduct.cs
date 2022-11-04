namespace IlluminareToys.Domain.Entities
{
    public class TagProduct : BaseEntity
    {
        public TagProduct(Guid productId, Guid tagId)
        {
            ProductId = productId;
            TagId = tagId;
        }

        public Guid ProductId { get; private set; }

        public Guid TagId { get; private set; }

        public Product Product { get; private set; }

        public Tag Tag { get; private set; }
    }
}
