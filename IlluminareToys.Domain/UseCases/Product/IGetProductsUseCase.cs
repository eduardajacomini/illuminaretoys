using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductsUseCase
    {
        Task<IEnumerable<GetProductOutput>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
