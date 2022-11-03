using AutoMapper;
using IlluminareToys.Domain.Outputs;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases;

namespace IlluminareToys.Application.UseCases
{
    public class GetTagByIdUseCase : IGetTagByIdUseCase
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public GetTagByIdUseCase(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<GetTagOutput> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _tagRepository.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<GetTagOutput>(entity);
        }
    }
}
