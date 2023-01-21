using AutoMapper;
using IlluminareToys.Domain.Outputs.Tag;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Tag;

namespace IlluminareToys.Application.UseCases.Tags
{
    public class GetTagsGroupsByGroupIdUseCase : IGetTagsGroupsByGroupIdUseCase
    {
        private readonly IMapper _mapper;
        private readonly ITagGroupRepository _tagGroupRepository;

        public GetTagsGroupsByGroupIdUseCase(IMapper mapper, ITagGroupRepository tagGroupRepository)
        {
            _mapper = mapper;
            _tagGroupRepository = tagGroupRepository;
        }

        public async Task<IEnumerable<GetTagGroupOutput>> ExecuteAsync(Guid groupId, CancellationToken cancellationToken)
        {
            //var entities = await _tagGroupRepository.ListAsync(x => x.GroupId.Equals(groupId) && x.Active, cancellationToken);

            //return _mapper.Map<IEnumerable<GetTagGroupOutput>>(entities);

            return Enumerable.Empty<GetTagGroupOutput>();
        }
    }
}
