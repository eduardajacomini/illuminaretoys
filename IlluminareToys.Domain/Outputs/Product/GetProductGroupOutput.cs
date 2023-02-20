using IlluminareToys.Domain.Outputs.Group;

namespace IlluminareToys.Domain.Outputs.Product
{
    public record GetProductGroupOutput
    {
        public Guid ProductId { get; private set; }

        public Guid GroupId { get; private set; }

        public GetProductOutput Product { get; private set; }

        public GetGroupOutput Group { get; private set; }

        public IEnumerable<GetProductGroupAgeOutput> ProductsGroupsAges { get; private set; }
    }
}
