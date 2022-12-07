using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs.Group;

namespace IlluminareToys.Domain.UseCases.Group
{
    public interface ICreateGroupUseCase
    {
        Task<CreateGroupOutput> ExecuteAsync(CreateGroupInput input, CancellationToken cancellationToken);
    }
}
