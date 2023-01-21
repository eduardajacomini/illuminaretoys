using IlluminareToys.Domain.Inputs.Products;
using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IAssociateGroupsToProductUseCase
    {
        Task<AssociateGroupsToProductOutput> ExecuteAsync(AssociateGroupsToProductInput input, CancellationToken cancellationToken);
    }
}
