using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IAssociateAgesUseCase
    {
        Task<AssociateAgesOutput> ExecuteAsync(Guid productId, CancellationToken cancellationToken);
    }
}
