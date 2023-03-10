namespace IlluminareToys.Domain.Entities
{
    public class ProductGroup : BaseEntity
    {
        public ProductGroup(Guid productId, Guid groupId)
        {
            ProductId = productId;
            GroupId = groupId;
        }

        public Guid ProductId { get; private set; }

        public Guid GroupId { get; private set; }

        public Product Product { get; private set; }

        public Group Group { get; private set; }

        public IEnumerable<ProductGroupAge> ProductsGroupsAges { get; private set; }
    }
}
