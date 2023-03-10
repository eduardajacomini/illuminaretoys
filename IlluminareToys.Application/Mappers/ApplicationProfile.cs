using AutoMapper;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Inputs.Ages;
using IlluminareToys.Domain.Inputs.Groups;
using IlluminareToys.Domain.Outputs.Age;
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
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.CategoryId))
                .ForMember(dest => dest.CategoryDescription, opt => opt.MapFrom(src => src.Category.CategoryDescription));

            CreateMap<Product, GetProductOutput>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.TagsProducts))
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.ProductsGroups)
                );

            CreateMap<Product, GetProductsByTagsOutput>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.TagsProducts));

            CreateMap<CreateGroupInput, Group>();

            CreateMap<Group, CreateGroupOutput>();
            CreateMap<Group, GetGroupOutput>();

            CreateMap<CreateAgeInput, Age>();

            CreateMap<Age, CreateAgeOutput>();

            CreateMap<Age, GetAgeOutput>();

            CreateMap<ProductAge, GetProductAgeOutput>();

            CreateMap<ProductGroup, GetProductGroupOutput>();

            CreateMap<ProductGroupAge, GetProductGroupAgeOutput>();
        }
    }
}
