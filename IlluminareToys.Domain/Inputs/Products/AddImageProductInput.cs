using Microsoft.AspNetCore.Http;

namespace IlluminareToys.Domain.Inputs.Products
{
    public record AddImageProductInput
    {
        public AddImageProductInput(IFormFile image, Guid productId)
        {
            Image = image;
            ProductId = productId;
        }

        public IFormFile Image { get; private set; }

        public Guid ProductId { get; private set; }
    }
}
