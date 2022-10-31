namespace IlluminareToys.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }

        public bool Active { get; private set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public void SetUnactive() => Active = false;
    }
}
