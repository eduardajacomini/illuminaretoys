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

        public string BlingCreatedAt { get; private set; }

        public string BlingUpdatedAt { get; private set; }

        public void SetCode(string value)
        {
            if (Code != value)
                Code = value;
        }

        public void SetDescription(string value)
        {
            if (Description != value)
                Description = value;
        }

        public void SetPrice(string value)
        {
            if (Price != value)
                Price = value;
        }

        public void SetPriceCost(string value)
        {
            if (PriceCost != value)
                PriceCost = value;
        }

        public void SetImageUrl(string value)
        {
            if (ImageUrl != value)
                ImageUrl = value;
        }

        public void SetCategoryId(string value)
        {
            if (CategoryId != value)
                CategoryId = value;
        }

        public void SetCategoryDescription(string value)
        {
            if (CategoryDescription != value)
                CategoryDescription = value;
        }

        public void SetUnity(string value)
        {
            if (Unity != value)
                Unity = value;
        }

        public void SetState(string value)
        {
            if (State != value)
                State = value;
        }

        public void SetBlingCreatedAt(string value)
        {
            if (BlingCreatedAt != value)
                BlingCreatedAt = value;
        }

        public void SetBlingUpdatedAt(string value)
        {
            if (BlingUpdatedAt != value)
                BlingUpdatedAt = value;
        }
    }
}
