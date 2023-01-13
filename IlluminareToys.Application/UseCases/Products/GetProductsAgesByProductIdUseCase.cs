using AutoMapper;
using IlluminareToys.Domain.Outputs.Product;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases.Products
{
    public class GetProductsAgesByProductIdUseCase : IGetProductsAgesByProductIdUseCase
    {
        private readonly IProductAgeRepository _productAgeRepository;
        private readonly IMapper _mapper;

        public GetProductsAgesByProductIdUseCase(IProductAgeRepository productAgeRepository, IMapper mapper)
        {
            _productAgeRepository = productAgeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductAgeOutput>> ExecuteAsync(Guid productId, CancellationToken cancellationToken)
        {
            var entities = await _productAgeRepository.ListAsync(x => x.ProductId.Equals(productId));

            return _mapper.Map<IEnumerable<GetProductAgeOutput>>(entities);
        }
    }
}
