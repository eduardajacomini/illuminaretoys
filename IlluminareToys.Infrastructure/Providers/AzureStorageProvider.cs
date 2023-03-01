using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using IlluminareToys.Domain.Providers;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace IlluminareToys.Infrastructure.Providers
{
    public class AzureStorageProvider : IAzureStorageProvider
    {
        private readonly string _storageConnectionString;
        private readonly string _storageContainer;

        public AzureStorageProvider(IConfiguration _configuration)
        {
            _storageConnectionString = _configuration.GetConnectionString("AzureBlob");
            _storageContainer = _configuration["AzureBlobContainer"];
        }

        public async Task<string> UploadImageAsync(string base64Image, string fileName, CancellationToken cancellationToken)
        {
            // Limpa o hash enviado
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

            // Gera um array de Bytes
            byte[] imageBytes = Convert.FromBase64String(data);

            var blobClient = new BlobClient(_storageConnectionString, _storageContainer, fileName);

            // Envia a imagem
            using var stream = new MemoryStream(imageBytes);

            //await blobClient.UploadAsync(stream, true, cancellationToken);
            await blobClient.UploadAsync(stream, new BlobUploadOptions
            {
                Conditions = null,
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType = "image/jpeg"
                }
            }, cancellationToken);

            // Retorna a URL da imagem
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
