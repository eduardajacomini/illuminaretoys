using AutoMapper;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Outputs;
using IlluminareToys.Infrastructure.Bling.Contracts;

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
            CreateMap<Tag, DeleteTagOutput>();

            CreateMap<ProductData, Product>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Categoria.CategoryId))
                .ForMember(dest => dest.CategoryDescription, opt => opt.MapFrom(src => src.Categoria.CategoryDescription));
        }
    }
}
