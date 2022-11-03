using AutoMapper;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;

namespace IlluminareToys.Application.Mappers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Tag, CreateTagOutput>();

            CreateMap<Tag, GetTagOutput>();

            CreateMap<CreateTagInput, Tag>();

            CreateMap<Tag, UpdateTagOutput>();
        }
    }
}
