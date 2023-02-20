using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProdutsByAgeIdsUseCase
    {
        Task<IEnumerable<GetProductOutput>> ExecuteAsync(IEnumerable<Guid> ageIds, bool useOnlyProductAgeRelation, CancellationToken cancellationToken);
    }
}
