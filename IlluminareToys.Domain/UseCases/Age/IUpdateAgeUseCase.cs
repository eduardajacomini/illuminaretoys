using IlluminareToys.Domain.Inputs.Ages;
using IlluminareToys.Domain.Outputs.Age;

namespace IlluminareToys.Domain.UseCases.Age
{
    public interface IUpdateAgeUseCase
    {
        Task<UpdateAgeOutput> ExecuteAsync(UpdateAgeInput input, CancellationToken cancellationToken);
    }
}
