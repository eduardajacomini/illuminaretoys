using AutoMapper;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Outputs.Product;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases.Products
{
    public class GetProdutsByAgeIdsUseCase : IGetProdutsByAgeIdsUseCase
    {
        private readonly IAgeRepository _ageRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupAgeRepository _productGroupAgeRepository;
        private readonly IProductAgeRepository _productAgeRepository;
        private readonly IMapper _mapper;
        private readonly IProductGroupRepository _productGroupRepository;

        public GetProdutsByAgeIdsUseCase(IAgeRepository ageRepository,
                                         IProductRepository productRepository,
                                         IProductGroupAgeRepository productGroupAgeRepository,
                                         IProductAgeRepository productAgeRepository,
                                         IMapper mapper,
                                         IProductGroupRepository productGroupRepository)
        {
            _ageRepository = ageRepository;
            _productRepository = productRepository;
            _productGroupAgeRepository = productGroupAgeRepository;
            _productAgeRepository = productAgeRepository;
            _mapper = mapper;
            _productGroupRepository = productGroupRepository;
        }
        public async Task<IEnumerable<GetProductOutput>> ExecuteAsync(IEnumerable<Guid> ageIds, bool useOnlyProductAgeRelation, CancellationToken cancellationToken)
        {
            if (!ageIds.Any())
            {
                return Enumerable.Empty<GetProductOutput>();
            }

            var ages = await _ageRepository.ListAsync(x => ageIds.Contains(x.Id), cancellationToken);
            var finalAgeIds = ages.Select(x => x.Id);

            var productAges = await _productAgeRepository.ListAsync(x => finalAgeIds.Contains(x.AgeId), cancellationToken);

            var productsFoundByProductAge = await _productRepository.ListAsync(x => productAges.Select(x => x.ProductId).Contains(x.Id),
                                                              x => x.Description,
                                                              cancellationToken);

            if (useOnlyProductAgeRelation)
            {
                return _mapper.Map<IEnumerable<GetProductOutput>>(productsFoundByProductAge);
            }

            var productsResult = new List<Product>();

            productsResult.AddRange(productsFoundByProductAge);

            var productsGroupsAges = await _productGroupAgeRepository.ListAsync(x => finalAgeIds.Contains(x.AgeId), cancellationToken);
            var productsGroupsIds = productsGroupsAges.Select(x => x.ProductGroupId);

            var productsGroups = await _productGroupRepository.ListAsync(x => productsGroupsIds.Contains(x.Id), cancellationToken);
            var productIds = productsGroups.Select(x => x.ProductId);

            var productsFoundByProductGroupAge = await _productRepository.ListAsync(x => productIds.Contains(x.Id), x => x.Description, cancellationToken);

            productsResult.AddRange(productsFoundByProductGroupAge);

            return _mapper.Map<IEnumerable<GetProductOutput>>(productsResult.DistinctBy(x => x.Id));
        }
    }
}
