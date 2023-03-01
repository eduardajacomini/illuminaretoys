namespace IlluminareToys.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string BlingId { get; private set; }

        public string Code { get; private set; }

        public string Description { get; private set; }

        public string Price { get; private set; }

        public string PriceCost { get; private set; }

        public string ImageUrl { get; private set; }

        public string CategoryId { get; private set; }

        public string CategoryDescription { get; private set; }

        public string Unity { get; private set; }

        public string State { get; private set; }

        public string Brand { get; private set; }

        public string BlingCreatedAt { get; private set; }

        public string BlingUpdatedAt { get; private set; }

        public DateTime SynchronizedAt { get; private set; }

        public int? CurrentStock { get; private set; }

        public IEnumerable<TagProduct> TagsProducts { get; private set; }
        public IEnumerable<ProductAge> ProductsAges { get; private set; }

        public IEnumerable<ProductGroup> ProductsGroups { get; private set; }

        public void SetCurrentStock(int? value)
        {
            if (CurrentStock != value)
            {
                SynchronizedAt = DateTime.Now;
                CurrentStock = value;
            }
        }

        public void SetBrand(string value)
        {
            if (Brand != value)
            {
                SynchronizedAt = DateTime.Now;
                Brand = value;
            }
        }

        public void SetCode(string value)
        {
            if (Code != value)
            {
                SynchronizedAt = DateTime.Now;
                Code = value;
            }
        }

        public void SetDescription(string value)
        {
            if (Description != value)
            {
                SynchronizedAt = DateTime.Now;
                Description = value;
            }
        }

        public void SetPrice(string value)
        {
            if (Price != value)
            {
                SynchronizedAt = DateTime.Now;
                Price = value;
            }
        }

        public void SetPriceCost(string value)
        {
            if (PriceCost != value)
            {
                SynchronizedAt = DateTime.Now;
                PriceCost = value;
            }
        }

        public void SetImageUrl(string value)
        {
            if (ImageUrl != value)
            {
                ImageUrl = value;
            }
        }

        public void SetCategoryId(string value)
        {
            if (CategoryId != value)
            {
                SynchronizedAt = DateTime.Now;
                CategoryId = value;
            }
        }

        public void SetCategoryDescription(string value)
        {
            if (CategoryDescription != value)
            {
                SynchronizedAt = DateTime.Now;
                CategoryDescription = value;
            }
        }

        public void SetUnity(string value)
        {
            if (Unity != value)
            {
                SynchronizedAt = DateTime.Now;
                Unity = value;
            }
        }

        public void SetState(string value)
        {
            if (State != value)
            {
                SynchronizedAt = DateTime.Now;
                State = value;
            }
        }

        public void SetBlingCreatedAt(string value)
        {
            if (BlingCreatedAt != value)
            {
                SynchronizedAt = DateTime.Now;
                BlingCreatedAt = value;
            }
        }

        public void SetBlingUpdatedAt(string value)
        {
            if (BlingUpdatedAt != value)
            {
                SynchronizedAt = DateTime.Now;
                BlingUpdatedAt = value;
            }
        }
    }
}
