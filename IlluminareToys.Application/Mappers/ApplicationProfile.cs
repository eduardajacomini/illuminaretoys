using AutoMapper;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs.Groups;
using IlluminareToys.Domain.Outputs.Group;
using IlluminareToys.Domain.Outputs.Product;
using IlluminareToys.Domain.Outputs.Tag;
using IlluminareToys.Infrastructure.Bling.Contracts;

namespace IlluminareToys.Application.Mappers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<TagProduct, GetTagProductOutput>();

            CreateMap<Tag, CreateTagOutput>();

            CreateMap<Tag, GetTagOutput>();

            CreateMap<Tag, UpdateTagOutput>();

            CreateMap<Tag, DeleteTagOutput>();

            CreateMap<ProductData, Product>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Categoria.CategoryId))
                .ForMember(dest => dest.CategoryDescription, opt => opt.MapFrom(src => src.Categoria.CategoryDescription));

            CreateMap<Product, GetProductOutput>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.TagsProducts));

            CreateMap<Product, GetProductsByTagsOutput>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.TagsProducts));

            CreateMap<CreateGroupInput, Group>();

            CreateMap<Group, CreateGroupOutput>();
            CreateMap<Group, GetGroupOutput>();

            CreateMap<TagGroup, GetTagGroupOutput>();
        }
    }
}
