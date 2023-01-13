using IlluminareToys.Domain.Outputs.Age;

namespace IlluminareToys.Domain.UseCases.Age
{
    public interface IGetAgesUseCase
    {
        Task<IEnumerable<GetAgeOutput>> ExecuteAsync(CancellationToken cancellationToken);

    }
}
