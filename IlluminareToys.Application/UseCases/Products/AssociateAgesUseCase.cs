using IlluminareToys.Domain.Outputs.Product;
using IlluminareToys.Domain.UseCases.Age;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases.Products
{
    public class AssociateAgesUseCase : IAssociateAgesUseCase
    {
        private readonly IGetAgesUseCase _getAgesUseCase;
        private readonly IGetProductByIdUseCase _getProductByIdUseCase;

        public AssociateAgesUseCase(IGetAgesUseCase getAgesUseCase, IGetProductByIdUseCase getProductByIdUseCase)
        {
            _getAgesUseCase = getAgesUseCase;
            _getProductByIdUseCase = getProductByIdUseCase;
        }

        public async Task<AssociateAgesOutput> ExecuteAsync(Guid productId, CancellationToken cancellationToken)
        {
            var product = await _getProductByIdUseCase.ExecuteAsync(productId, cancellationToken);
            var ages = await _getAgesUseCase.ExecuteAsync(cancellationToken);

            return new AssociateAgesOutput
            {
                Ages = ages,
                Product = product
            };
        }
    }
}
