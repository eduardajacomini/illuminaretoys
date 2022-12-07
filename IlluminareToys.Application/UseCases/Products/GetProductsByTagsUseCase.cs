using AutoMapper;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases.Products
{
    public class GetProductsByTagsUseCase : IGetProductsByTagsUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly ITagProductRepository _tagProductRepository;
        private readonly IMapper _mapper;

        public GetProductsByTagsUseCase(IProductRepository productRepository, ITagProductRepository tagProductRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _tagProductRepository = tagProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductsByTagsOutput>> ExecuteAsync(GetProductsByTagsInput input, CancellationToken cancellationToken)
        {
            if (!input.Tags.Any())
            {
                var allProducts = await _productRepository.ListAsync(x => x.Active, x => x.Description, cancellationToken);

                return _mapper.Map<IEnumerable<GetProductsByTagsOutput>>(allProducts);
            }

            var tagsProduct = await _tagProductRepository.ListAsync(x => input.Tags.Contains(x.TagId), cancellationToken);

            var productIds = tagsProduct.Select(x => x.ProductId);

            var products = await _productRepository.ListAsync(x => productIds.Contains(x.Id), x => x.Description, cancellationToken);

            var mapped = _mapper.Map<IEnumerable<GetProductsByTagsOutput>>(products);

            return mapped;
        }
    }
}
