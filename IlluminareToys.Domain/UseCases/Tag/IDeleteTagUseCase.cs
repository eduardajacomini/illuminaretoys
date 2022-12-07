using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs.Tag;

namespace IlluminareToys.Domain.UseCases.Tag
{
    public interface IDeleteTagUseCase
    {
        Task<DeleteTagOutput> ExecuteAsync(DeleteTagInput input, CancellationToken cancellationToken);
    }
}
