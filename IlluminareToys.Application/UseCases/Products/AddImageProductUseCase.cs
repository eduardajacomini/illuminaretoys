using FluentValidation;
using FluentValidation.Results;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs.Products;
using IlluminareToys.Domain.Outputs.Product;
using IlluminareToys.Domain.Providers;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Product;
using IlluminareToys.Infrastructure.Bling;
using IlluminareToys.Infrastructure.Bling.Contracts;

namespace IlluminareToys.Application.UseCases.Products
{
    public class AddImageProductUseCase : IAddImageProductUseCase
    {
        private readonly IAzureStorageProvider _azureStorageProvider;
        private readonly IValidator<AddImageProductInput> _validator;
        private readonly IProductRepository _productRepository;
        private readonly IBlingClient _blingClient;

        public AddImageProductUseCase(IAzureStorageProvider azureStorageProvider,
            IValidator<AddImageProductInput> validator,
            IProductRepository productRepository,
            IBlingClient blingClient)
        {
            _azureStorageProvider = azureStorageProvider;
            _validator = validator;
            _productRepository = productRepository;
            _blingClient = blingClient;
        }

        public async Task<AddImageProductOutput> ExecuteAsync(AddImageProductInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new AddImageProductOutput(validationResult.Errors);
            }

            var product = await _productRepository.GetByIdAsync(input.ProductId);

            if (product is null)
            {
                return new AddImageProductOutput(new ValidationFailure(nameof(input.ProductId), "Produto não encontrado."));
            }

            using var memoryStream = new MemoryStream();

            input.Image.CopyTo(memoryStream);

            var imageBytes = memoryStream.ToArray();

            var imageBase64 = Convert.ToBase64String(imageBytes);

            var fileName = string.Concat(product.Id, ".jpg");

            var imageUrl = await _azureStorageProvider.UploadImageAsync(imageBase64, fileName, cancellationToken);

            product.SetImageUrl(imageUrl);

            await _productRepository.UpdateAsync(product, cancellationToken);

            await PutImageInProductAsync(product, imageUrl, cancellationToken);

            return new();
        }

        private async Task PutImageInProductAsync(Product product, string imageUrl, CancellationToken cancellationToken)
        {
            try
            {
                var request = new PutImageInProductRequest
                {
                    Code = product.Code,
                    Description = product.Description,
                    Images = new ImageRequest
                    {
                        Url = imageUrl
                    }
                };

                await _blingClient.PutImageInProductAsync(request, cancellationToken);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
