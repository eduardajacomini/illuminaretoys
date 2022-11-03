using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases;

namespace IlluminareToys.Application.UseCases
{
    public class DeleteTagUseCase : IDeleteTagUseCase
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<DeleteTagInput> _validator;

        public DeleteTagUseCase(ITagRepository tagRepository, IMapper mapper, IValidator<DeleteTagInput> validator)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<DeleteTagOutput> ExecuteAsync(DeleteTagInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new DeleteTagOutput(validationResult.Errors);
            }

            var entity = await _tagRepository.GetByIdAsync(input.Id, cancellationToken);

            if (entity is null)
            {
                return new DeleteTagOutput(new ValidationFailure(nameof(input.Id), "Tag não encontrada."));
            }

            await _tagRepository.DeleteAsync(entity, cancellationToken);

            return _mapper.Map<DeleteTagOutput>(entity);
        }
    }
}
