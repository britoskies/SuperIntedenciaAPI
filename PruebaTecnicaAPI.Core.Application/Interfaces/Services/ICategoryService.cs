using PruebaTecnicaAPI.Core.Application.Dtos;
using PruebaTecnicaAPI_SuperIntendenciaDeBancos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.Core.Application.Interfaces.Services
{
    public interface ICategoryService : IGenericService<CategoryDto, CategoryCreateDto, Category>
    {

    }
}
