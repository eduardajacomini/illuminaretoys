using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IAddImageProductUseCase
    {
        Task<AddImageProductOutput> ExecuteAsync(AddImageProductInput input, CancellationToken cancellationToken);
    }
}
