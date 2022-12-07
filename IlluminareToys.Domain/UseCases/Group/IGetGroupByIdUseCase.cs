using IlluminareToys.Domain.Outputs.Group;

namespace IlluminareToys.Domain.UseCases.Group
{
    public interface IGetGroupByIdUseCase
    {
        Task<GetGroupOutput> ExecuteAsync(Guid id, CancellationToken cancellationToken);
    }
}
