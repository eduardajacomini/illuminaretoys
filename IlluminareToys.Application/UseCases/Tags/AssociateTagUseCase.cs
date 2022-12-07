using IlluminareToys.Domain.Outputs;
using IlluminareToys.Domain.UseCases.Product;
using IlluminareToys.Domain.UseCases.Tag;

namespace IlluminareToys.Application.UseCases.Tags
{
    public class AssociateTagUseCase : IAssociateTagUseCase
    {
        private readonly IGetTagsUseCase _getTagsUseCase;
        private readonly IGetProductByIdUseCase _getProductByIdUseCase;

        public AssociateTagUseCase(IGetTagsUseCase getTagsUseCase, IGetProductByIdUseCase getProductByIdUseCase)
        {
            _getTagsUseCase = getTagsUseCase;
            _getProductByIdUseCase = getProductByIdUseCase;
        }

        public async Task<AssociateTagsOutput> ExecuteAsync(Guid productId, CancellationToken cancellationToken)
        {
            var tags = await _getTagsUseCase.ExecuteAsync(cancellationToken);
            var product = await _getProductByIdUseCase.ExecuteAsync(productId, cancellationToken);

            return new AssociateTagsOutput
            {
                Product = product,
                Tags = tags
            };
        }
    }
}
