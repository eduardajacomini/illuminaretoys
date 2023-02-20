using IlluminareToys.Domain.Outputs.Age;

namespace IlluminareToys.Domain.Outputs.Product
{
    public record GetProductGroupAgeOutput
    {
        public Guid ProductGroupId { get; set; }

        public Guid AgeId { get; set; }

        public GetProductGroupOutput ProductGroup { get; set; }

        public GetAgeOutput Age { get; set; }
    }
}
