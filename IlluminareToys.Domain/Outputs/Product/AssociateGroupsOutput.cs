using IlluminareToys.Domain.Outputs.Group;

namespace IlluminareToys.Domain.Outputs.Product
{
    public class AssociateGroupsOutput
    {
        public GetProductOutput Product { get; set; }

        public IEnumerable<GetGroupOutput> Groups { get; set; }
    }
}
