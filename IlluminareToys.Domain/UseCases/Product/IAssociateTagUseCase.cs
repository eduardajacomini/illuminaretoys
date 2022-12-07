using IlluminareToys.Domain.Outputs.Tag;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IAssociateTagUseCase
    {
        Task<AssociateTagsOutput> ExecuteAsync(Guid productId, CancellationToken cancellationToken);
    }
}
