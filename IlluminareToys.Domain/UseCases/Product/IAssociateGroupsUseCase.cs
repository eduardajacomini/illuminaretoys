using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IAssociateGroupsUseCase
    {
        Task<AssociateGroupsOutput> ExecuteAsync(Guid productId, CancellationToken cancellationToken);
    }
}
