using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Domain.UseCases.Tag
{
    public interface IGetTagByIdUseCase
    {
        Task<GetTagOutput> ExecuteAsync(Guid id, CancellationToken cancellationToken);
    }
}
