using IlluminareToys.Domain.Outputs.Tag;

namespace IlluminareToys.Domain.UseCases.Tag
{
    public interface IGetTagsGroupsByTagIdUseCase
    {
        Task<IEnumerable<GetTagGroupOutput>> ExecuteAsync(Guid tagId, CancellationToken cancellationToken);
    }
}
