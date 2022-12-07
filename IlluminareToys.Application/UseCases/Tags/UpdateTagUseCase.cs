using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs.Tag;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Tag;

namespace IlluminareToys.Application.UseCases.Tags
{
    public class UpdateTagUseCase : IUpdateTagUseCase
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateTagInput> _validator;

        public UpdateTagUseCase(ITagRepository tagRepository, IMapper mapper, IValidator<UpdateTagInput> validator)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateTagOutput> ExecuteAsync(UpdateTagInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new UpdateTagOutput(validationResult.Errors);
            }

            var entity = await _tagRepository.GetByIdAsync(input.Id, cancellationToken);

            if (entity is null)
            {
                return new UpdateTagOutput(new ValidationFailure(nameof(input.Id), "Tag não encontrada."));
            }

            entity.SetDescription(input.Description);

            await _tagRepository.UpdateAsync(entity, cancellationToken);


            return _mapper.Map<UpdateTagOutput>(entity);
        }
    }
}
