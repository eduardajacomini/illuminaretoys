using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IAssociateTagUseCase
    {
        Task<AssociateTagsOutput> ExecuteAsync(Guid productId, CancellationToken cancellationToken);
    }
}
