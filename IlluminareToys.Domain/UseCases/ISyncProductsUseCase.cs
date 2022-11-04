namespace IlluminareToys.Domain.UseCases
{
    public interface ISyncProductsUseCase
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
