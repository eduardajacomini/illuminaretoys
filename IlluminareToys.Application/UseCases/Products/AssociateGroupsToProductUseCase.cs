using FluentValidation;
using FluentValidation.Results;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs.Products;
using IlluminareToys.Domain.Outputs.Product;
using IlluminareToys.Domain.Repositories;

namespace IlluminareToys.Domain.UseCases.Product
{
    public class AssociateGroupsToProductUseCase : IAssociateGroupsToProductUseCase
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IProductRepository _productRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IValidator<AssociateGroupsToProductInput> _validator;

        public AssociateGroupsToProductUseCase(IProductGroupRepository productGroupRepository, IValidator<AssociateGroupsToProductInput> validator, IProductRepository productRepository, IGroupRepository groupRepository)
        {
            _productGroupRepository = productGroupRepository;
            _validator = validator;
            _productRepository = productRepository;
            _groupRepository = groupRepository;
        }

        public async Task<AssociateGroupsToProductOutput> ExecuteAsync(AssociateGroupsToProductInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new AssociateGroupsToProductOutput(validationResult.Errors);
            }

            var product = await _productRepository.FirstOrDefaultAsync(x => x.BlingId.Equals(input.ProductId));

            if (product is null)
            {
                return new AssociateGroupsToProductOutput(new ValidationFailure(nameof(input.ProductId), "Produto não encontrado."));
            }

            foreach (var groupId in input.GroupIds)
            {
                var group = await _productGroupRepository.GetByIdAsync(groupId, cancellationToken);

                if (group is not null)
                {
                    var productGroup = new ProductGroup(product.Id, groupId);

                    await _productGroupRepository.AddAsync(productGroup, cancellationToken);
                }
            }

            return new();
        }
    }
}
