using AutoMapper;
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
            var productAgesIds = productAges.Select(x => x.ProductId);

            var productsFoundByProductAge = await _productRepository.ListAsync(x => productAgesIds.Contains(x.Id) && x.CurrentStock > 0,
                                                              x => x.Description,
                                                              cancellationToken);

            return _mapper.Map<IEnumerable<GetProductOutput>>(productsFoundByProductAge);
        }
    }
}
