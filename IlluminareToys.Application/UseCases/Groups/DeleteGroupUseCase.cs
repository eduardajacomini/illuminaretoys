using FluentValidation.Results;
using IlluminareToys.Domain.Outputs.Group;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Group;

namespace IlluminareToys.Application.UseCases.Groups
{
    public class DeleteGroupUseCase : IDeleteGroupUseCase
    {
        private readonly IGroupRepository _groupRepository;

        public DeleteGroupUseCase(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<DeleteGroupOutput> ExecuteAsync(Guid groupId, CancellationToken cancellationToken)
        {
            if (groupId.Equals(Guid.Empty))
            {
                return new DeleteGroupOutput(new ValidationFailure(nameof(groupId), "Id inválido."));
            }

            var entity = await _groupRepository.GetByIdAsync(groupId, cancellationToken);

            if (entity is null)
            {
                return new DeleteGroupOutput(new ValidationFailure(nameof(groupId), "Grupo não encontrado."));
            }

            await _groupRepository.LogicDeleteAsync(entity, cancellationToken);

            return new();
        }
    }
}
