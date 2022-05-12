using AutoMapper;
using Production.Software.Application.Commands;
using Production.Software.Application.Responses;
using Production.Software.Core.Entities;

namespace Production.Software.Application.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile() {
        CreateMap <Product, ProductResponse>().ReverseMap();
        CreateMap <Product, CreateProductCommand>().ReverseMap();
    }
}