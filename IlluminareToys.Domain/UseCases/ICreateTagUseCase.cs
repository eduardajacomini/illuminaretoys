using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Domain.UseCases
{
    public interface ICreateTagUseCase
    {
        Task<CreateTagOutput> ExecuteAsync(CreateTagInput input, CancellationToken cancellationToken);
    }
}
