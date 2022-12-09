using AutoMapper;
using FluentValidation;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs.Tags;
using IlluminareToys.Domain.Outputs.Tag;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Tag;

namespace IlluminareToys.Application.UseCases.Tags
{
    public class CreateTagUseCase : ICreateTagUseCase
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTagInput> _validator;
        private readonly ICreateTagsGroupsUseCase _createTagsGroupsUseCase;

        public CreateTagUseCase(ITagRepository tagRepository,
                                IMapper mapper,
                                IValidator<CreateTagInput> validator,
                                ICreateTagsGroupsUseCase createTagsGroupsUseCase)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
            _validator = validator;
            _createTagsGroupsUseCase = createTagsGroupsUseCase;
        }

        public async Task<CreateTagOutput> ExecuteAsync(CreateTagInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new CreateTagOutput(validationResult.Errors);
            }

            var entity = new Tag(input.Description);

            await _tagRepository.AddAsync(entity, cancellationToken);

            foreach (var tagGroup in input.TagsGroups)
            {
                tagGroup.TagId = entity.Id;
            }

            await _createTagsGroupsUseCase.ExecuteAsync(new CreateTagsGroupsInput(input.TagsGroups), cancellationToken);

            return _mapper.Map<CreateTagOutput>(entity);
        }
    }
}
