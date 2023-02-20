using FluentValidation;
using FluentValidation.Results;
using IlluminareToys.Domain.Inputs.Ages;
using IlluminareToys.Domain.Outputs.Age;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Age;

namespace IlluminareToys.Application.UseCases.Ages
{
    public class UpdateAgeUseCase : IUpdateAgeUseCase
    {
        private readonly IAgeRepository _repository;
        private readonly IValidator<UpdateAgeInput> _validator;

        public UpdateAgeUseCase(IAgeRepository repository, IValidator<UpdateAgeInput> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<UpdateAgeOutput> ExecuteAsync(UpdateAgeInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new UpdateAgeOutput(validationResult.Errors);
            }

            var entity = await _repository.GetByIdAsync(input.Id, cancellationToken);

            if (entity is null)
            {
                return new UpdateAgeOutput(new ValidationFailure(nameof(input.Id), "Grupo não encontrado."));
            }

            entity.SetQuantity(input.Quantity);
            entity.SetAgeType(input.Type);

            await _repository.UpdateAsync(entity, cancellationToken);


            return new();
        }
    }
}
