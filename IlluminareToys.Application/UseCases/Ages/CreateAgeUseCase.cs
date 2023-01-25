using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs.Ages;
using IlluminareToys.Domain.Outputs.Age;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Age;

namespace IlluminareToys.Application.UseCases.Ages
{
    public class CreateAgeUseCase : ICreateAgeUseCase
    {
        private readonly IAgeRepository _repository;
        private readonly IValidator<CreateAgeInput> _validator;
        private readonly IMapper _mapper;

        public CreateAgeUseCase(IAgeRepository repository,
            IValidator<CreateAgeInput> validator,
            IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<CreateAgeOutput> ExecuteAsync(CreateAgeInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new CreateAgeOutput(validationResult.Errors);
            }

            var ageExists = await _repository.FirstOrDefaultAsync(x => x.Quantity.Equals(input.Quantity) &&
                                                                      x.Type.Equals(input.Type));

            if (ageExists is not null)
            {
                return new CreateAgeOutput(new ValidationFailure("Idade", "Idade informada já existe."));
            }

            var entity = _mapper.Map<Age>(input);

            await _repository.AddAsync(entity, cancellationToken);

            return _mapper.Map<CreateAgeOutput>(entity);
        }
    }
}
