using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductsGroupsAgesByGroupIdUseCase
    {
        Task<IEnumerable<GetProductGroupAgeOutput>> ExecuteAsync(Guid groupId, CancellationToken cancellationToken);
    }
}
