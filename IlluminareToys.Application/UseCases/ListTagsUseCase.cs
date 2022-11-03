﻿using AutoMapper;
using IlluminareToys.Domain.Outputs;
using IlluminareToys.Domain.Repositories;
using IlluminareToys.Domain.UseCases;

namespace IlluminareToys.Application.UseCases
{
    public class ListTagsUseCase : IListTagsUseCase
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public ListTagsUseCase(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListTagsOutput>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var entities = await _tagRepository.ListAsync(cancellationToken);

            var output = _mapper.Map<List<ListTagsOutput>>(entities);

            return output;
        }
    }
}
