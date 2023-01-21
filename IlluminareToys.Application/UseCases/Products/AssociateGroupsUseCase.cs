using IlluminareToys.Domain.Outputs.Product;
using IlluminareToys.Domain.UseCases.Group;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases.Products
{
    public class AssociateGroupsUseCase : IAssociateGroupsUseCase
    {
        private readonly IGetGroupsUseCase _getGroupsUseCase;
        private readonly IGetProductByIdUseCase _getProductByIdUseCase;

        public AssociateGroupsUseCase(IGetGroupsUseCase getGroupsUseCase, IGetProductByIdUseCase getProductByIdUseCase)
        {
            _getGroupsUseCase = getGroupsUseCase;
            _getProductByIdUseCase = getProductByIdUseCase;
        }

        public async Task<AssociateGroupsOutput> ExecuteAsync(Guid productId, CancellationToken cancellationToken)
        {
            var product = await _getProductByIdUseCase.ExecuteAsync(productId, cancellationToken);
            var groups = await _getGroupsUseCase.ExecuteAsync(cancellationToken);

            return new AssociateGroupsOutput
            {
                Groups = groups,
                Product = product
            };
        }
    }
}
