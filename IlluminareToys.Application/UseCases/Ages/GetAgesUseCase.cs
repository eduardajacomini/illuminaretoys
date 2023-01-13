using AutoMapper;
using IlluminareToys.Domain.Outputs.Age;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Age;

namespace IlluminareToys.Application.UseCases.Ages
{
    public class GetAgesUseCase : IGetAgesUseCase
    {
        private readonly IAgeRepository _repository;
        private readonly IMapper _mapper;

        public GetAgesUseCase(IAgeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAgeOutput>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var entities = await _repository.ListAsync(x => x.Active, x => x.Quantity, cancellationToken);

            var output = _mapper.Map<IEnumerable<GetAgeOutput>>(entities);

            return output;
        }
    }
}
