﻿using AutoMapper;
using IlluminareToys.Domain.Outputs;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases;

namespace IlluminareToys.Application.UseCases
{
    public class GetTagsUseCase : IGetTagsUseCase
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public GetTagsUseCase(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetTagOutput>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var entities = await _tagRepository.ListAsync(x => x.Active, x => x.Description, cancellationToken);

            var output = _mapper.Map<IEnumerable<GetTagOutput>>(entities);

            return output;
        }
    }
}
