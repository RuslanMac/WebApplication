using AutoMapper.QueryableExtensions;
using Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Service.Dtos;
using Service.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// Base service class
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    /// <typeparam name="TDto">Dto</typeparam>
    public abstract class BaseService<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected IWebProjectMapper Mapper { get; set; }

        public IDbRepository<TEntity> Repository { get; set; }

        protected BaseService(IWebProjectMapper mapper, IDbRepository<TEntity> repository)
        {
            Mapper = mapper;
            Repository = repository;
        }

        public virtual async Task<TDto> AddAsync(TDto dto)
        {
            //get model from db
            var entity = Mapper.Map<TEntity>(dto);
            await Repository.AddAsync(entity);
            //map to appropriate dto
            var map = await GetById(entity.Id);
            return map;

        }

        public virtual async Task<List<TDto>> AddAsync(IList<TDto> list)
        {
            var result = new List<TDto>();
            foreach (var item in list)
            {
                result.Add(await AddAsync(item));
            }
            return result;
        }



        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            // if model we want to update exists
            var id = await Repository.Get(x => x.Id == dto.Id).Select(x => x.Id).SingleOrDefaultAsync();
            if (id > 0)
            {
                await Repository.UpdateAsync(entity);
                return dto;
            }
            throw new ArgumentException("The object does not exists yet");

        }

        public virtual async Task DeleteAsync(int id)
        {
            //If model exists
            var model = await Repository.Get(x => x.Id == id).FirstOrDefaultAsync();
            if (model == null)
                throw new ArgumentException("The object with this id does not exist");
            await Repository.DeleteAsync(model);
        }


        public virtual async Task<TDto> GetById(int id)
        {
            //gets result from db and maps to appropriate dto
            var result = await Repository
                .Get(x => x.Id == id)
                .ProjectTo<TDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
            return result;
        }

        public virtual async Task<List<TDto>> GetAll()
        {
            ///gets result from db and maps to list of dto
            var result = await Repository
                 .GetAll()
                 .ProjectTo<TDto>(Mapper.ConfigurationProvider)
                 .ToListAsync();

            return result;


        }

    }
}
