namespace IlluminareToys.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Description { get; private set; }

        public IEnumerable<TagGroup> TagsGroups { get; private set; }
    }
}
