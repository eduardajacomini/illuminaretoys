using IlluminareToys.Infrastructure.Bling.Contracts;

namespace IlluminareToys.Infrastructure.Bling
{
    public interface IBlingClient
    {
        Task<GetProductsResponse> GetProductsAsync(CancellationToken cancellationToken);
        Task PutImageInProductAsync(PutImageInProductRequest request, CancellationToken cancellationToken);
    }
}
