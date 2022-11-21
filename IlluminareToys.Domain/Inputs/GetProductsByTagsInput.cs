namespace IlluminareToys.Domain.Inputs
{
    public class GetProductsByTagsInput
    {
        public IEnumerable<Guid> Tags { get; set; } = new List<Guid>();
    }
}
