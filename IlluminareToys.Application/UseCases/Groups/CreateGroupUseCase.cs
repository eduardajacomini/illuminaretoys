using AutoMapper;
using FluentValidation;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs.Group;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Group;

namespace IlluminareToys.Application.UseCases.Groups
{
    public class CreateGroupUseCase : ICreateGroupUseCase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IValidator<CreateGroupInput> _validator;
        private readonly IMapper _mapper;

        public CreateGroupUseCase(IGroupRepository groupRepository, IValidator<CreateGroupInput> validator, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<CreateGroupOutput> ExecuteAsync(CreateGroupInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new CreateGroupOutput(validationResult.Errors);
            }

            var entity = _mapper.Map<Group>(input);

            await _groupRepository.AddAsync(entity, cancellationToken);

            return _mapper.Map<CreateGroupOutput>(entity);
        }
    }
}
