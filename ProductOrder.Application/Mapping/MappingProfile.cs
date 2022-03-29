using AutoMapper;
using ProductOrder.Application.Commands;
using ProductOrder.Application.Responses;
using ProductOrder.Core.Models;

namespace ProductOrder.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductResponse, Product>();
            
            CreateMap<Product, CreateProductCommand>();
            CreateMap<CreateProductCommand, Product>();

            CreateMap<Category, CategoryResponse>();
            CreateMap<CategoryResponse, Category>();

            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<CreateCategoryCommand, Category>();
        }
    }
}