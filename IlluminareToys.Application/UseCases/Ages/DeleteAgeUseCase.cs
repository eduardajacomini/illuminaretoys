using FluentValidation.Results;
using IlluminareToys.Domain.Outputs.Age;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Age;

namespace IlluminareToys.Application.UseCases.Ages
{
    public class DeleteAgeUseCase : IDeleteAgeUseCase
    {
        private readonly IAgeRepository _repository;

        public DeleteAgeUseCase(IAgeRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteAgeOutput> ExecuteAsync(Guid ageId, CancellationToken cancellationToken)
        {
            if (ageId.Equals(Guid.Empty))
            {
                return new DeleteAgeOutput(new ValidationFailure(nameof(ageId), "Id inválido."));
            }

            var entity = await _repository.GetByIdAsync(ageId, cancellationToken);

            if (entity is null)
            {
                return new DeleteAgeOutput(new ValidationFailure(nameof(ageId), "Grupo não encontrado."));
            }

            await _repository.LogicDeleteAsync(entity, cancellationToken);

            return new();
        }
    }
}
