using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.Core.Application.Interfaces.Services
{
    public interface IGenericService<Dto, CreateDto, Entity> 
        where Entity : class
        where Dto : class
        where CreateDto : class
    {
        Task<List<Dto>> GetAllAsync();
        Task<List<Dto>> GetAllWithIncludeAsync(List<string> props);
        Task<Dto> GetByIdAsync(int id);
        Task<Dto> AddAsync(CreateDto dto);
        Task UpdateAsync(CreateDto dto, int id);
        Task DeleteAsync(int id);
    }
}
