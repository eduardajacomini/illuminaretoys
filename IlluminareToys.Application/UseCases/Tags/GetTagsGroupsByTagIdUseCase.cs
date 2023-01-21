using AutoMapper;
using IlluminareToys.Domain.Outputs.Tag;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Tag;

namespace IlluminareToys.Application.UseCases.Tags
{
    public class GetTagsGroupsByTagIdUseCase : IGetTagsGroupsByTagIdUseCase
    {
        private readonly IMapper _mapper;
        private readonly ITagGroupRepository _tagGroupRepository;

        public GetTagsGroupsByTagIdUseCase(IMapper mapper, ITagGroupRepository tagGroupRepository)
        {
            _mapper = mapper;
            _tagGroupRepository = tagGroupRepository;
        }

        public async Task<IEnumerable<GetTagGroupOutput>> ExecuteAsync(Guid tagId, CancellationToken cancellationToken)
        {
            //var entities = await _tagGroupRepository.ListAsync(x => x.TagId.Equals(tagId) && x.Active, cancellationToken);

            //return _mapper.Map<IEnumerable<GetTagGroupOutput>>(entities);

            return Enumerable.Empty<GetTagGroupOutput>();
        }
    }
}
