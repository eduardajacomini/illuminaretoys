using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductByIdUseCase
    {
        Task<GetProductOutput> ExecuteAsync(Guid id, CancellationToken cancellationToken);
    }
}
