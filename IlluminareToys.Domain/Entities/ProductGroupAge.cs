namespace IlluminareToys.Domain.Entities
{
    public class ProductGroupAge : BaseEntity
    {
        public ProductGroupAge(Guid productGroupId, Guid ageId)
        {
            ProductGroupId = productGroupId;
            AgeId = ageId;
        }

        public Guid ProductGroupId { get; private set; }

        public Guid AgeId { get; private set; }

        public ProductGroup ProductGroup { get; private set; }

        public Age Age { get; private set; }

        public void SetAgeId(Guid ageId) => AgeId = ageId;
    }
}
