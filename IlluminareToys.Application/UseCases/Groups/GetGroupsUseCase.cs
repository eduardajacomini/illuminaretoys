using AutoMapper;
using IlluminareToys.Domain.Outputs.Group;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Group;

namespace IlluminareToys.Application.UseCases.Groups
{
    public class GetGroupsUseCase : IGetGroupsUseCase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetGroupsUseCase(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetGroupOutput>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var entities = await _groupRepository.ListAsync(x => x.Active, x => x.Description, cancellationToken);

            var output = _mapper.Map<IEnumerable<GetGroupOutput>>(entities);

            return output;
        }
    }
}
