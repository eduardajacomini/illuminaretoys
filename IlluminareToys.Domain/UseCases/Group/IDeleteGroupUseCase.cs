using IlluminareToys.Domain.Outputs.Group;

namespace IlluminareToys.Domain.UseCases.Group
{
    public interface IDeleteGroupUseCase
    {
        Task<DeleteGroupOutput> ExecuteAsync(Guid groupId, CancellationToken cancellationToken);
    }
}
