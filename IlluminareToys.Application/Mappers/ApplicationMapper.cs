using AutoMapper;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Application.Mappers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Tag, CreateTagOutput>();

            CreateMap<IEnumerable<Tag>, IEnumerable<ListTagsOutput>>();

            CreateMap<CreateTagInput, Tag>();
        }
    }
}
