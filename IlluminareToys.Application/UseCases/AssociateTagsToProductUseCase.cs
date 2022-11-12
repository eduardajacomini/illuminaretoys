using FluentValidation;
using FluentValidation.Results;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases
{
    public class AssociateTagsToProductUseCase : IAssociateTagsToProductUseCase
    {
        private readonly IValidator<AssociateTagsToProductInput> _validator;
        private readonly ITagProductRepository _tagProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITagRepository _tagRepository;

        public AssociateTagsToProductUseCase(IValidator<AssociateTagsToProductInput> validator, ITagProductRepository tagProductRepository, IProductRepository productRepository, ITagRepository tagRepository)
        {
            _validator = validator;
            _tagProductRepository = tagProductRepository;
            _productRepository = productRepository;
            _tagRepository = tagRepository;
        }

        public async Task<AssociateTagsToProductOutput> ExecuteAsync(AssociateTagsToProductInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new AssociateTagsToProductOutput(validationResult.Errors);
            }

            var product = await _productRepository.FirstOrDefaultAsync(x => x.BlingId.Equals(input.BlingProductId));

            if (product is null)
            {
                return new AssociateTagsToProductOutput(new ValidationFailure(nameof(input.BlingProductId), "Produto não encontrado."));
            }

            var tagsExists = await _tagProductRepository.ListAsync(x => x.ProductId.Equals(product.Id));

            if (tagsExists.Any())
                await _tagProductRepository.DeleteAllAsync(tagsExists);

            foreach (var tagId in input.TagIds)
            {
                var tag = await _tagRepository.GetByIdAsync(tagId);

                if (tag is not null)
                {
                    var tagProduct = new TagProduct(product.Id, tag.Id);

                    await _tagProductRepository.AddAsync(tagProduct);
                }
            }

            return new();
        }
    }
}
