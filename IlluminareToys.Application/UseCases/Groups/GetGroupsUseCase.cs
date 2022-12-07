using AutoMapper;
using IlluminareToys.Domain.Outputs.Group;
using IlluminareToys.Domain.Repositories;

namespace IlluminareToys.Application.UseCases.Groups
{
    public class GetGroupsUseCase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetGroupsUseCase(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetGroupOutput>> ExecuteAsync()
        {
            return Enumerable.Empty<GetGroupOutput>();
        }
    }
}
