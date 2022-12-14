using IlluminareToys.Domain.Outputs.Tag;

namespace IlluminareToys.Domain.UseCases.Tag
{
    public interface IGetTagsGroupsByGroupIdUseCase
    {
        Task<IEnumerable<GetTagGroupOutput>> ExecuteAsync(Guid groupId, CancellationToken cancellationToken);
    }
}
