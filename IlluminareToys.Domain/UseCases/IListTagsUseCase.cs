using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Domain.UseCases
{
    public interface IListTagsUseCase
    {
        Task<IEnumerable<ListTagsOutput>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
