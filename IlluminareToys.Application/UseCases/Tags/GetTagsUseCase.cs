using AutoMapper;
using IlluminareToys.Domain.Outputs.Tag;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Tag;

namespace IlluminareToys.Application.UseCases.Tags
{
    public class GetTagsUseCase : IGetTagsUseCase
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public GetTagsUseCase(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetTagOutput>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var entities = await _tagRepository.ListAsync(x => x.Active, x => x.Description, cancellationToken);

            var output = _mapper.Map<IEnumerable<GetTagOutput>>(entities);

            return output;
        }
    }
}
