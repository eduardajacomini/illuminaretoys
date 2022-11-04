using AutoMapper;
using IlluminareToys.Domain.Outputs;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases
{
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductOutput> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<GetProductOutput>(entity);
        }
    }
}
