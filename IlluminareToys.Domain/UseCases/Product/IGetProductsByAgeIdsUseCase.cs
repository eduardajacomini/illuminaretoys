using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductsByAgeIdsUseCase
    {
        Task<IEnumerable<GetProductOutput>> ExecuteAsync(Guid groupId, IEnumerable<Guid> ageIds, bool useProductAgeRelation, CancellationToken cancellationToken);
    }
}
