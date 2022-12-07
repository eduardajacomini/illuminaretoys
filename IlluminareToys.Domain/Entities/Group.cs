namespace IlluminareToys.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Description { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<TagGroup> TagsGroups { get; private set; }

        public void SetDescription(string value)
        {
            if (value != Description)
                Description = value;
        }

        public void SetName(string value)
        {
            if (value != Name)
                Name = value;
        }
    }
}
