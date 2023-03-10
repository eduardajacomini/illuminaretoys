using AutoMapper;
using IlluminareToys.Domain.Outputs.Product;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases.Products
{
    public class GetProductsUseCase : IGetProductsUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductOutput>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var entities = await _productRepository.ListAsync(x => x.Active, x => x.Description, cancellationToken);

            return _mapper.Map<IEnumerable<GetProductOutput>>(entities);
        }
    }
}
