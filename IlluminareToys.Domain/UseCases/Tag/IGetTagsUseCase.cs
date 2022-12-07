using IlluminareToys.Domain.Outputs.Tag;

namespace IlluminareToys.Domain.UseCases.Tag
{
    public interface IGetTagsUseCase
    {
        Task<IEnumerable<GetTagOutput>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
