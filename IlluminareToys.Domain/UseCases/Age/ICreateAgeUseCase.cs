using IlluminareToys.Domain.Inputs.Ages;
using IlluminareToys.Domain.Outputs.Age;

namespace IlluminareToys.Domain.UseCases.Age
{
    public interface ICreateAgeUseCase
    {
        Task<CreateAgeOutput> ExecuteAsync(CreateAgeInput input, CancellationToken cancellationToken);
    }
}
