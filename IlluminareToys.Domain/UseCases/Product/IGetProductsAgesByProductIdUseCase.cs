using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductsAgesByProductIdUseCase
    {
        Task<IEnumerable<GetProductAgeOutput>> ExecuteAsync(Guid productId, CancellationToken cancellationToken);
    }
}
