using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs.Tag;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IAssociateTagsToProductUseCase
    {
        Task<AssociateTagsToProductOutput> ExecuteAsync(AssociateTagsToProductInput input, CancellationToken cancellationToken);
    }
}
