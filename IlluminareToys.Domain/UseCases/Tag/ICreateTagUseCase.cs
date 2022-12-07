using IlluminareToys.Domain.Inputs.Tags;
using IlluminareToys.Domain.Outputs.Tag;

namespace IlluminareToys.Domain.UseCases.Tag
{
    public interface ICreateTagUseCase
    {
        Task<CreateTagOutput> ExecuteAsync(CreateTagInput input, CancellationToken cancellationToken);
    }
}
