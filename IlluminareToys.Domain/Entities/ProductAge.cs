namespace IlluminareToys.Domain.Entities
{
    public class ProductAge : BaseEntity
    {
        public ProductAge(Guid productId, Guid ageId)
        {
            ProductId = productId;
            AgeId = ageId;
        }

        public Guid ProductId { get; private set; }

        public Guid AgeId { get; private set; }

        public Product Product { get; private set; }

        public Age Age { get; private set; }
    }
}
