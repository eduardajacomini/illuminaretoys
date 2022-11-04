using AutoMapper;
using FluentValidation;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases.Tag;

namespace IlluminareToys.Application.UseCases
{
    public class CreateTagUseCase : ICreateTagUseCase
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTagInput> _validator;

        public CreateTagUseCase(ITagRepository tagRepository,
                                IMapper mapper,
                                IValidator<CreateTagInput> validator)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateTagOutput> ExecuteAsync(CreateTagInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new CreateTagOutput(validationResult.Errors);
            }

            var entity = _mapper.Map<Tag>(input);

            await _tagRepository.AddAsync(entity, cancellationToken);

            return _mapper.Map<CreateTagOutput>(entity);
        }
    }
}
