using IlluminareToys.Domain.Outputs.Age;

namespace IlluminareToys.Domain.Outputs.Product
{
    public record GetProductGroupAgeOutput
    {
        public IEnumerable<GetProductGroupAgeOutputItem> ItemsToShow { get; set; }

        public IEnumerable<GetProductGroupAgeOutputItem> ItemsToSelect { get; set; }
    }

    public record GetProductGroupAgeOutputItem
    {
        public Guid ProductGroupId { get; set; }

        public Guid AgeId { get; set; }

        public GetProductGroupOutput ProductGroup { get; set; }

        public GetAgeOutput Age { get; set; }
    }
}
