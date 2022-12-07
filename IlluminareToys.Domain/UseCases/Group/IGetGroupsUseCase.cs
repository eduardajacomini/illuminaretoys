using IlluminareToys.Domain.Outputs.Group;

namespace IlluminareToys.Domain.UseCases.Group
{
    public interface IGetGroupsUseCase
    {
        Task<IEnumerable<GetGroupOutput>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
