using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IDeleteProductUseCase
    {
        Task<DeleteProductOutput> ExecuteAsync(DeleteProductInput input, CancellationToken cancellationToken);
    }
}
