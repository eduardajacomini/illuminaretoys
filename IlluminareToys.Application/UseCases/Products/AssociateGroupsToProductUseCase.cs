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
        private readonly IAgeRepository _ageRepository;
        private readonly IProductGroupAgeRepository _productGroupAgeRepository;
        private readonly IValidator<AssociateGroupsToProductInput> _validator;

        public AssociateGroupsToProductUseCase(IProductGroupRepository productGroupRepository,
                                               IValidator<AssociateGroupsToProductInput> validator,
                                               IProductRepository productRepository,
                                               IGroupRepository groupRepository,
                                               IAgeRepository ageRepository,
                                               IProductGroupAgeRepository productGroupAgeRepository)
        {
            _productGroupRepository = productGroupRepository;
            _validator = validator;
            _productRepository = productRepository;
            _groupRepository = groupRepository;
            _ageRepository = ageRepository;
            _productGroupAgeRepository = productGroupAgeRepository;
        }

        public async Task<AssociateGroupsToProductOutput> ExecuteAsync(AssociateGroupsToProductInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new AssociateGroupsToProductOutput(validationResult.Errors);
            }


            foreach (var item in input.ProductGroups)
            {

                var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);

                if (product is null)
                {
                    return new AssociateGroupsToProductOutput(new ValidationFailure(nameof(item.ProductId), "Produto não encontrado."));
                }

                var group = await _groupRepository.GetByIdAsync(item.GroupId, cancellationToken);

                if (group is null)
                {
                    return new AssociateGroupsToProductOutput(new ValidationFailure(nameof(item.GroupId), "Grupo não encontrado."));
                }



                //var age = await _ageRepository.GetByIdAsync(item.AgeId, cancellationToken);

                //if (age is null)
                //{
                //    return new AssociateGroupsToProductOutput(new ValidationFailure(nameof(item.AgeId), "Idade não encontrada."));
                //}


                var productGroup = await _productGroupRepository.FirstOrDefaultAsync(x => x.GroupId.Equals(item.GroupId) && x.ProductId.Equals(item.ProductId), cancellationToken);

                if (productGroup is null)
                {
                    if (!item.AgeIds.Any())
                    {
                        continue;
                    }

                    var newProductGroup = new ProductGroup(item.ProductId, item.GroupId);

                    await _productGroupRepository.AddAsync(newProductGroup, cancellationToken);

                    foreach (var ageId in item.AgeIds)
                    {
                        var newProductGroupAge = new ProductGroupAge(newProductGroup.Id, ageId);

                        await _productGroupAgeRepository.AddAsync(newProductGroupAge, cancellationToken);
                    }

                    continue;
                }

                var existingProductGroupAges = await _productGroupAgeRepository.ListAsync(x => x.ProductGroupId.Equals(productGroup.Id), cancellationToken);

                await _productGroupAgeRepository.DeleteAllAsync(existingProductGroupAges, cancellationToken);

                foreach (var ageId in item.AgeIds)
                {
                    var newProductGroupAge = new ProductGroupAge(productGroup.Id, ageId);

                    await _productGroupAgeRepository.AddAsync(newProductGroupAge, cancellationToken);
                }
            }

            //foreach (var groupId in input.GroupIds)
            //{
            //    var group = await _productGroupRepository.GetByIdAsync(groupId, cancellationToken);

            //    if (group is not null)
            //    {
            //        var productGroup = new ProductGroup(product.Id, groupId);

            //        await _productGroupRepository.AddAsync(productGroup, cancellationToken);
            //    }
            //}//

            return new();
        }
    }
}
