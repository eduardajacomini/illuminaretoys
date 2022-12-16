using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductsByCategoryUseCase
    {
        Task<IEnumerable<GetProductOutput>> ExecuteAsync(string category, CancellationToken cancellationToken);
    }
}
