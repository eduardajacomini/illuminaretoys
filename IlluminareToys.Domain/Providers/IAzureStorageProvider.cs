namespace IlluminareToys.Domain.Providers
{
    public interface IAzureStorageProvider
    {
        Task<string> UploadImageAsync(string base64Image, CancellationToken cancellationToken);
    }
}
