using FluentValidation;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;
using IlluminareToys.Domain.Providers;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;

namespace IlluminareToys.Application.UseCases
{
    public class AddImageProductUseCase : IAddImageProductUseCase
    {
        private readonly IAzureStorageProvider _azureStorageProvider;
        private readonly IValidator<AddImageProductInput> _validator;
        private readonly IProductRepository _productRepository;

        public AddImageProductUseCase(IAzureStorageProvider azureStorageProvider,
            IValidator<AddImageProductInput> validator,
            IProductRepository productRepository)
        {
            _azureStorageProvider = azureStorageProvider;
            _validator = validator;
            _productRepository = productRepository;
        }

        public async Task<AddImageProductOutput> ExecuteAsync(AddImageProductInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new AddImageProductOutput(validationResult.Errors);
            }

            using var memoryStream = new MemoryStream();

            input.Image.CopyTo(memoryStream);

            var imageBytes = memoryStream.ToArray();

            var imageBase64 = Convert.ToBase64String(imageBytes);

            var imageUrl = await _azureStorageProvider.UploadImageAsync(imageBase64, cancellationToken);

            var product = await _productRepository.GetByIdAsync(input.ProductId);

            product.SetImageUrl(imageUrl);

            await _productRepository.UpdateAsync(product, cancellationToken);

            return new();
        }
    }
}
