using IlluminareToys.Domain.Outputs.Product;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases.Products
{
    public class GetProductCategoriesUseCase : IGetProductCategoriesUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetProductCategoriesUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<GetProductCategoryOutput>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var products = await _productRepository.ListAsync(x => x.Active, cancellationToken);

            var categories = products
                .DistinctBy(x => x.CategoryDescription)
                .Select(x => new GetProductCategoryOutput
                {
                    Id = x.CategoryId,
                    Description = x.CategoryDescription
                })
                .OrderBy(x => x.Description);

            return categories;
        }
    }
}
