using IlluminareToys.Domain.Outputs.Age;

namespace IlluminareToys.Domain.Outputs.Product
{
    public class AssociateAgesOutput : BaseOutput
    {
        public GetProductOutput Product { get; set; }

        public IEnumerable<GetAgeOutput> Ages { get; set; }
    }
}
