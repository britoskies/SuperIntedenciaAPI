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
    public class CategoryService : GenericService<CategoryDto, CategoryCreateDto, Category>, ICategoryService
    {
        public CategoryService(ICategoryRepo repo, IMapper mapper) : base(repo, mapper) { }
    }
}
