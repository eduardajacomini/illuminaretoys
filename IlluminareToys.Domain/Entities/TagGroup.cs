namespace IlluminareToys.Domain.Entities
{
    public class TagGroup : BaseEntity
    {
        public TagGroup(Guid tagId, Guid groupId, string age)
        {
            TagId = tagId;
            GroupId = groupId;
            Age = age;
        }

        public Guid TagId { get; private set; }

        public Guid GroupId { get; private set; }

        public string Age { get; private set; }

        public Tag Tag { get; private set; }

        public Group Group { get; private set; }
    }
}
