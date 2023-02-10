using AutoMapper;
using IlluminareToys.Domain.Outputs.Product;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases.Products
{
    public class GetProductsByAgeIdsUseCase : IGetProductsByAgeIdsUseCase
    {
        private readonly IAgeRepository _ageRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupAgeRepository _productGroupAgeRepository;
        private readonly IProductAgeRepository _productAgeRepository;
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        private readonly IProductGroupRepository _productGroupRepository;

        public GetProductsByAgeIdsUseCase(IAgeRepository ageRepository,
                                         IProductRepository productRepository,
                                         IProductGroupAgeRepository productGroupAgeRepository,
                                         IProductAgeRepository productAgeRepository,
                                         IMapper mapper,
                                         IGroupRepository groupRepository,
                                         IProductGroupRepository productGroupRepository)
        {
            _ageRepository = ageRepository;
            _productRepository = productRepository;
            _productGroupAgeRepository = productGroupAgeRepository;
            _productAgeRepository = productAgeRepository;
            _mapper = mapper;
            _groupRepository = groupRepository;
            _productGroupRepository = productGroupRepository;
        }

        public async Task<IEnumerable<GetProductOutput>> ExecuteAsync(Guid groupId, IEnumerable<Guid> ageIds, bool useProductAgeRelation, CancellationToken cancellationToken)
        {
            var ages = await _ageRepository.ListAsync(x => ageIds.Contains(x.Id), cancellationToken);
            var finalAgeIds = ages.Select(x => x.Id);

            if (!useProductAgeRelation)
            {
                var productsGroupsAges = await _productGroupAgeRepository.ListAsync(x => finalAgeIds.Contains(x.AgeId), cancellationToken);
                var productsGroupsIds = productsGroupsAges.Select(x => x.ProductGroupId);

                var productsGroups = await _productGroupRepository.ListAsync(x => productsGroupsIds.Contains(x.Id), cancellationToken);
                var productIds = productsGroups.Where(x => x.GroupId.Equals(groupId)).Select(x => x.ProductId);

                var entities = await _productRepository.ListAsync(x => productIds.Contains(x.Id), x => x.Description, cancellationToken);

                return _mapper.Map<IEnumerable<GetProductOutput>>(entities);
            }

            var productAges = await _productAgeRepository.ListAsync(x => finalAgeIds.Contains(x.AgeId), cancellationToken);

            var products = await _productRepository.ListAsync(x => productAges.Select(x => x.ProductId).Contains(x.Id),
                                                              x => x.Description,
                                                              cancellationToken);

            return _mapper.Map<IEnumerable<GetProductOutput>>(products);

            //var tagsGroups = await _tagGroupRepository.ListAsync(x => x.GroupId.Equals(groupId) &&
            //                                                          x.Age.Equals(age)
            //                                                     , cancellationToken);

            //var tagsIds = tagsGroups.Select(x => x.TagId);

            //var tagsProducts = await _tagProductRepository.ListAsync(x => tagsIds.Contains(x.TagId) &&
            //                                                        x.Active
            //                                                        , cancellationToken);

            //var productsIds = tagsProducts.Select(x => x.ProductId);

            //var products = await _productRepository.ListAsync(x => productsIds.Contains(x.Id), x => x.Description, cancellationToken);

            //return _mapper.Map<IEnumerable<GetProductOutput>>(products);

            //return Enumerable.Empty<GetProductOutput>();
        }
    }
}
