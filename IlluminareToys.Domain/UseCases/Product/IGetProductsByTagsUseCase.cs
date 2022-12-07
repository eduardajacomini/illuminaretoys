using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Domain.UseCases.Product
{
    public interface IGetProductsByTagsUseCase
    {
        Task<IEnumerable<GetProductsByTagsOutput>> ExecuteAsync(GetProductsByTagsInput input, CancellationToken cancellationToken);
    }
}
