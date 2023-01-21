using AutoMapper;
using IlluminareToys.Domain.Outputs.Product;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases.Products
{
    public class GetProductsByGroupIdUseCase : IGetProductsByGroupIdUseCase
    {
        private readonly ITagGroupRepository _tagGroupRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITagProductRepository _tagProductRepository;
        private readonly IMapper _mapper;

        public GetProductsByGroupIdUseCase(ITagGroupRepository tagGroupRepository,
                                              IProductRepository productRepository,
                                              ITagProductRepository tagProductRepository,
                                              IMapper mapper)
        {
            _tagGroupRepository = tagGroupRepository;
            _productRepository = productRepository;
            _tagProductRepository = tagProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductOutput>> ExecuteAsync(Guid groupId, string age, CancellationToken cancellationToken)
        {

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

            return Enumerable.Empty<GetProductOutput>();
        }
    }
}
