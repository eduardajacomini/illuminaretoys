using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Domain.UseCases
{
    public interface IGetTagsUseCase
    {
        Task<IEnumerable<GetTagOutput>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
