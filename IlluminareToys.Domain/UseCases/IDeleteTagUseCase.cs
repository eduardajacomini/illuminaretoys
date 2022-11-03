using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Domain.UseCases
{
    public interface IDeleteTagUseCase
    {
        Task<DeleteTagOutput> ExecuteAsync(DeleteTagInput input, CancellationToken cancellationToken);
    }
}
