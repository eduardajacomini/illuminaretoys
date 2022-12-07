using IlluminareToys.Domain.Inputs.Products;
using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IAddImageProductUseCase
    {
        Task<AddImageProductOutput> ExecuteAsync(AddImageProductInput input, CancellationToken cancellationToken);
    }
}
