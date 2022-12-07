using IlluminareToys.Domain.Inputs.Groups;
using IlluminareToys.Domain.Outputs.Group;

namespace IlluminareToys.Domain.UseCases.Group
{
    public interface IUpdateGroupUseCase
    {
        Task<UpdateGroupOutput> ExecuteAsync(UpdateGroupInput input, CancellationToken cancellationToken);
    }
}
