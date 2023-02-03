using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductsByAgeIdsUseCase
    {
        Task<IEnumerable<GetProductOutput>> ExecuteAsync(IEnumerable<Guid> ageIds, bool useProductAgeRelation, CancellationToken cancellationToken);
    }
}
