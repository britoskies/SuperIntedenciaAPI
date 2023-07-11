using AutoMapper;
using PruebaTecnicaAPI.Core.Application.Dtos;
using PruebaTecnicaAPI.Core.Application.Interfaces.Repositories;
using PruebaTecnicaAPI.Core.Application.Interfaces.Services;
using PruebaTecnicaAPI_SuperIntendenciaDeBancos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.Core.Application.Services
{
    public class ProductService : GenericService<ProductDto, ProductCreateDto, Product>, IProductService
    {
        public ProductService(IProductRepo repo, IMapper mapper) : base(repo, mapper) { }
    }
}
