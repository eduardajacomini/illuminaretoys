using AutoMapper;
using IlluminareToys.Domain.Outputs.Age;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Age;

namespace IlluminareToys.Application.UseCases.Ages
{
    public class GetAgeByIdUseCase : IGetAgeByIdUseCase
    {
        private readonly IAgeRepository _repository;
        private readonly IMapper _mapper;

        public GetAgeByIdUseCase(IAgeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAgeOutput> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<GetAgeOutput>(entity);
        }
    }
}
