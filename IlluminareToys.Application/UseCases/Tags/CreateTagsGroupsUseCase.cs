using FluentValidation;
using IlluminareToys.Domain.Inputs.Tags;
using IlluminareToys.Domain.Outputs.Tag;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Tag;

namespace IlluminareToys.Application.UseCases.Tags
{
    public class CreateTagsGroupsUseCase : ICreateTagsGroupsUseCase
    {
        private readonly ITagGroupRepository _tagGroupRepository;
        private readonly IValidator<CreateTagsGroupsInput> _validator;

        public CreateTagsGroupsUseCase(ITagGroupRepository tagGroupRepository, IValidator<CreateTagsGroupsInput> validator)
        {
            _tagGroupRepository = tagGroupRepository;
            _validator = validator;
        }

        public async Task<CreateTagGroupOutput> ExecuteAsync(CreateTagsGroupsInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new CreateTagGroupOutput(validationResult.Errors);
            }

            //foreach (var item in input.TagsGroups.Where(x => !x.Age.IsNullOrWhiteSpace()))
            //{
            //    var existingEntities = await _tagGroupRepository.ListAsync(x => x.GroupId.Equals(item.GroupId) &&
            //                                                                    x.TagId.Equals(item.TagId), cancellationToken);

            //    await _tagGroupRepository.DeleteAllAsync(existingEntities, cancellationToken);

            //    var entity = new TagGroup(item.TagId, item.GroupId, item.Age);

            //    await _tagGroupRepository.AddAsync(entity, cancellationToken);
            //}

            return new();
        }
    }
}
