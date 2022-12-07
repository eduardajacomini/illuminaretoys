using IlluminareToys.Domain.Inputs.Tags;
using IlluminareToys.Domain.Outputs.Tag;

namespace IlluminareToys.Domain.UseCases.Tag
{
    public interface ICreateTagsGroupsUseCase
    {
        Task<CreateTagGroupOutput> ExecuteAsync(CreateTagsGroupsInput input, CancellationToken cancellationToken);
    }
}
