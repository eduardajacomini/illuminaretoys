using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductCategoriesUseCase
    {
        Task<IEnumerable<GetProductCategoryOutput>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
