using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.Outputs.Tag
{
    public class AssociateTagsOutput
    {
        public IEnumerable<GetTagOutput> Tags { get; set; }

        public GetProductOutput Product { get; set; }
    }
}
