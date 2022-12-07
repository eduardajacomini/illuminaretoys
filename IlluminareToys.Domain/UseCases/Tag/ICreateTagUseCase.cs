using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs.Tag;

namespace IlluminareToys.Domain.UseCases.Tag
{
    public interface ICreateTagUseCase
    {
        Task<CreateTagOutput> ExecuteAsync(CreateTagInput input, CancellationToken cancellationToken);
    }
}
