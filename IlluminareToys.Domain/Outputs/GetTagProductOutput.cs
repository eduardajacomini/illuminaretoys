namespace IlluminareToys.Domain.Outputs
{
    public class GetTagProductOutput
    {
        public Guid Id { get; private set; }

        public Guid ProductId { get; private set; }

        public Guid TagId { get; private set; }

        public GetTagOutput Tag { get; set; }
    }
}
