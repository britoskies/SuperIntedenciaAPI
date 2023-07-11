using AutoMapper;
using PruebaTecnicaAPI.Core.Application.Dtos;
using PruebaTecnicaAPI.Core.Application.Interfaces.Repositories;
using PruebaTecnicaAPI.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.Core.Application.Services
{
    public class GenericService<Dto, CreateDto, Entity> : IGenericService<Dto, CreateDto, Entity>
        where Entity : class
        where Dto : class
        where CreateDto : class
    {

        private readonly IGenericRepo<Entity> _repo;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepo<Entity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Dto> AddAsync(CreateDto dto)
        {
            Entity mappedData = _mapper.Map<Entity>(dto);
            Entity addedEntity = await _repo.AddAsync(mappedData);
            return _mapper.Map<Dto>(addedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            Entity entity = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(entity);
        }

        public async Task<List<Dto>> GetAllAsync()
        {
            List<Entity> entity = await _repo.GetAllAsync();
            return _mapper.Map<List<Dto>>(entity);
        }

        public async Task<List<Dto>> GetAllWithIncludeAsync(List<string> props)
        {
            List<Entity> entity = await _repo.GetAllWithIncludeAsync(props);
            return _mapper.Map<List<Dto>>(entity);
        }

        public async Task<Dto> GetByIdAsync(int id)
        {
            Entity entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<Dto>(entity);
        }

        public async Task UpdateAsync(CreateDto dto, int id)
        {
            Entity entity = await _repo.GetByIdAsync(id);
            entity = _mapper.Map(dto, entity);
            await _repo.UpdateAsync(entity);
        }
    }
}
