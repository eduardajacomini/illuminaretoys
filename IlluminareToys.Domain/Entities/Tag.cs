namespace IlluminareToys.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Description { get; private set; }

        public IEnumerable<TagProduct> TagsProducts { get; private set; }

        public void SetDescription(string description) => Description = description;
    }
}
