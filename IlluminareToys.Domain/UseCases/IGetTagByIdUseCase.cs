using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Domain.UseCases
{
    public interface IGetTagByIdUseCase
    {
        Task<GetTagOutput> ExecuteAsync(Guid id, CancellationToken cancellationToken);
    }
}
