using IlluminareToys.Domain.Outputs.Age;

namespace IlluminareToys.Domain.UseCases.Age
{
    public interface IGetAgeByIdUseCase
    {
        Task<GetAgeOutput> ExecuteAsync(Guid id, CancellationToken cancellationToken);
    }
}
