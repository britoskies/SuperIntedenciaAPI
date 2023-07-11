using AutoMapper;
using PruebaTecnicaAPI.Core.Application.Dtos;
using PruebaTecnicaAPI.Core.Application.Dtos.Account;
using PruebaTecnicaAPI_SuperIntendenciaDeBancos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<ProductDto, Product>()
                .ReverseMap()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Category.Name));

            CreateMap<ProductCreateDto, Product>()
                .ReverseMap();
            
            CreateMap<CategoryDto, Category>()
                .ReverseMap()
                .ForMember(x => x.ProductCount, opt => opt.MapFrom(x => x.Products.Count));

            CreateMap<CategoryCreateDto, Category>()
                .ReverseMap();

            CreateMap<AuthenticationRequest, LoginDto>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
