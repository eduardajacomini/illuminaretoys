using IlluminareToys.Domain.Inputs.Tags;
using IlluminareToys.Domain.Outputs.Tag;

namespace IlluminareToys.Domain.UseCases.Tag
{
    public interface IDeleteTagUseCase
    {
        Task<DeleteTagOutput> ExecuteAsync(DeleteTagInput input, CancellationToken cancellationToken);
    }
}
