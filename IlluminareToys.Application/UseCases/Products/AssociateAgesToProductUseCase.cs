using FluentValidation;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs.Products;
using IlluminareToys.Domain.Outputs.Tag;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases.Products
{
    public class AssociateAgesToProductUseCase : IAssociateAgesToProductUseCase
    {
        private readonly IProductAgeRepository _productAgeRepository;
        private readonly IValidator<AssociateAgesToProductInput> _validator;

        public AssociateAgesToProductUseCase(IProductAgeRepository productAgeRepository,
                                             IValidator<AssociateAgesToProductInput> validator)
        {
            _productAgeRepository = productAgeRepository;
            _validator = validator;
        }

        public async Task<AssociateTagsToProductOutput> ExecuteAsync(AssociateAgesToProductInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new AssociateTagsToProductOutput(validationResult.Errors);
            }

            foreach (var age in input.Ages)
            {
                var entity = await _productAgeRepository.FirstOrDefaultAsync(x => x.ProductId.Equals(input.ProductId) &&
                                                                  x.AgeId.Equals(age.AgeId),
                                                                  cancellationToken);

                if (entity is not null && !age.IsChecked)
                {
                    await _productAgeRepository.DeleteAsync(entity, cancellationToken);

                    continue;
                }

                if (entity is null)
                {
                    var productAge = new ProductAge(input.ProductId, age.AgeId);

                    await _productAgeRepository.AddAsync(productAge, cancellationToken);
                }
            }

            return new();
        }
    }
}
