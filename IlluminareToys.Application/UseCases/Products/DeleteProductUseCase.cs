using FluentValidation;
using FluentValidation.Results;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases.Products
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<DeleteProductInput> _validator;

        public DeleteProductUseCase(IProductRepository productRepository, IValidator<DeleteProductInput> validator)
        {
            _productRepository = productRepository;
            _validator = validator;
        }

        public async Task<DeleteProductOutput> ExecuteAsync(DeleteProductInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new DeleteProductOutput(validationResult.Errors);
            }

            var entity = await _productRepository.GetByIdAsync(input.Id);

            if (entity is null)
            {
                return new DeleteProductOutput(new ValidationFailure(nameof(input.Id), "Produto não encontrado."));
            }

            await _productRepository.DeleteAsync(entity);

            return new();
        }
    }
}
