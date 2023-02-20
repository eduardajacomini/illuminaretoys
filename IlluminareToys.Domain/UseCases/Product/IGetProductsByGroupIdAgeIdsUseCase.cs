using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductsByGroupIdAgeIdsUseCase
    {
        Task<IEnumerable<GetProductOutput>> ExecuteAsync(Guid groupId, IEnumerable<Guid> ageIds, bool useOnlyProductAgeRelation, CancellationToken cancellationToken);
    }
}
