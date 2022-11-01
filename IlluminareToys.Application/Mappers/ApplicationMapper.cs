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
            CreateMap<CreateTagInput, Tag>()
                .ReverseMap();

            CreateMap<Tag, CreateTagOutput>();
        }
    }
}
