using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Domain.UseCases.Tag
{
    public interface IGetTagsUseCase
    {
        Task<IEnumerable<GetTagOutput>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
