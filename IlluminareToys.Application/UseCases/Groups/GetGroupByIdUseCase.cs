using AutoMapper;
using IlluminareToys.Domain.Outputs.Group;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Group;

namespace IlluminareToys.Application.UseCases.Groups
{
    public class GetGroupByIdUseCase : IGetGroupByIdUseCase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetGroupByIdUseCase(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<GetGroupOutput> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _groupRepository.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<GetGroupOutput>(entity);
        }
    }
}
