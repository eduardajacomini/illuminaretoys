using IlluminareToys.Domain.Outputs.Age;

namespace IlluminareToys.Domain.UseCases.Age
{
    public interface IDeleteAgeUseCase
    {
        Task<DeleteAgeOutput> ExecuteAsync(Guid ageId, CancellationToken cancellationToken);
    }
}
