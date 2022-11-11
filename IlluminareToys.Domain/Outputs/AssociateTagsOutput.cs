namespace IlluminareToys.Domain.Outputs
{
    public class AssociateTagsOutput
    {
        public IEnumerable<GetTagOutput> Tags { get; set; }

        public GetProductOutput Product { get; set; }
    }
}
