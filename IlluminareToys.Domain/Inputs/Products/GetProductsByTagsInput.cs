namespace IlluminareToys.Domain.Inputs.Products
{
    public class GetProductsByTagsInput
    {
        public IEnumerable<Guid> Tags { get; set; } = new List<Guid>();
    }
}
