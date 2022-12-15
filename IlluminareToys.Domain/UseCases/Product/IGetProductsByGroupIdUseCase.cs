using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductsByGroupIdUseCase
    {
        Task<IEnumerable<GetProductOutput>> ExecuteAsync(Guid groupId, string age, CancellationToken cancellationToken);
    }
}
