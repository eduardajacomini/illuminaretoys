namespace IlluminareToys.Domain.Outputs.Product
{
    public class GetProductAgeOutput : BaseOutput
    {
        public Guid AgeId { get; set; }

        public Guid ProductId { get; set; }
    }
}
