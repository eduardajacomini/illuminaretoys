using IlluminareToys.Domain.Inputs.Tags;
using IlluminareToys.Domain.Outputs.Tag;

namespace IlluminareToys.Domain.UseCases.Tag
{
    public interface IUpdateTagUseCase
    {
        Task<UpdateTagOutput> ExecuteAsync(UpdateTagInput input, CancellationToken cancellationToken);
    }
}
