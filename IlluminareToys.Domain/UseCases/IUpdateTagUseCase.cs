using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Domain.UseCases
{
    public interface IUpdateTagUseCase
    {
        Task<UpdateTagOutput> ExecuteAsync(UpdateTagInput input, CancellationToken cancellationToken);
    }
}
