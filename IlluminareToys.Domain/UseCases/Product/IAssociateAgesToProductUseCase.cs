using IlluminareToys.Domain.Inputs.Products;
using IlluminareToys.Domain.Outputs.Tag;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IAssociateAgesToProductUseCase
    {
        Task<AssociateTagsToProductOutput> ExecuteAsync(AssociateAgesToProductInput input, CancellationToken cancellationToken);
    }
}
