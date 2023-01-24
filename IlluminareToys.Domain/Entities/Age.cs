using IlluminareToys.Domain.Enums;

namespace IlluminareToys.Domain.Entities
{
    public class Age : BaseEntity
    {
        public int Quantity { get; private set; }

        public AgeType Type { get; private set; }

        public IEnumerable<ProductAge> ProductsAges { get; private set; }

        public IEnumerable<ProductGroupAge> ProductsGroupsAges { get; private set; }

        public void SetQuantity(int value)
        {
            if (Quantity != value)
            {
                Quantity = value;
            }
        }

        public void SetAgeType(AgeType type)
        {
            if (!Type.Equals(type))
                Type = type;
        }
    }
}
