using FluentValidation;
using FluentValidation.Results;
using IlluminareToys.Domain.Inputs.Groups;
using IlluminareToys.Domain.Outputs.Group;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Group;

namespace IlluminareToys.Application.UseCases.Groups
{
    public class UpdateGroupUseCase : IUpdateGroupUseCase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IValidator<UpdateGroupInput> _validator;

        public UpdateGroupUseCase(IGroupRepository groupRepository, IValidator<UpdateGroupInput> validator)
        {
            _groupRepository = groupRepository;
            _validator = validator;
        }

        public async Task<UpdateGroupOutput> ExecuteAsync(UpdateGroupInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new UpdateGroupOutput(validationResult.Errors);
            }

            var entity = await _groupRepository.GetByIdAsync(input.Id, cancellationToken);

            if (entity is null)
            {
                return new UpdateGroupOutput(new ValidationFailure(nameof(input.Id), "Grupo não encontrado."));
            }

            entity.SetDescription(input.Description);
            entity.SetName(input.Name);

            await _groupRepository.UpdateAsync(entity, cancellationToken);


            return new();
        }
    }
}
