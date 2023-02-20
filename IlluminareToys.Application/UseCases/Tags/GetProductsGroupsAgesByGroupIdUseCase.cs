using AutoMapper;
using IlluminareToys.Application.Extensions;
using IlluminareToys.Domain.Outputs.Product;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases.Tags
{
    public class GetProductsGroupsAgesByGroupIdUseCase : IGetProductsGroupsAgesByGroupIdUseCase
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IProductGroupAgeRepository _productGroupAgeRepository;
        private readonly IMapper _mapper;

        public GetProductsGroupsAgesByGroupIdUseCase(IProductGroupRepository productGroupRepository,
                                                     IProductGroupAgeRepository productGroupAgeRepository,
                                                     IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _productGroupAgeRepository = productGroupAgeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductGroupAgeOutput>> ExecuteAsync(Guid groupId, CancellationToken cancellationToken)
        {
            var productsGroups = await _productGroupRepository.ListAsync(x => x.GroupId.Equals(groupId), cancellationToken);

            if (!productsGroups.Any())
            {
                return Enumerable.Empty<GetProductGroupAgeOutput>();
            }

            var productsGroupsIds = productsGroups.Select(x => x.Id);

            var productsGroupsAges = await _productGroupAgeRepository.ListAsync(x => productsGroupsIds.Contains(x.ProductGroupId), cancellationToken);

            if (!productsGroupsAges.Any())
            {
                return Enumerable.Empty<GetProductGroupAgeOutput>();
            }

            return _mapper.Map<IEnumerable<GetProductGroupAgeOutput>>(productsGroupsAges.DistinctBy(x => x.AgeId)).ToOrderedByAge();
        }
    }
}
