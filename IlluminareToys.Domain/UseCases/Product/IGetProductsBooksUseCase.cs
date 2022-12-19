using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductsBooksUseCase
    {
        Task<IEnumerable<GetProductOutput>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
