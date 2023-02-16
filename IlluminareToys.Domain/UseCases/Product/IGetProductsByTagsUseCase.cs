using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductsByTagsUseCase
    {
        Task<IEnumerable<GetProductOutput>> ExecuteAsync(IEnumerable<Guid> tagIds, CancellationToken cancellationToken);
    }
}
