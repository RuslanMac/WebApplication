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
    public class ProjectService : BaseService<ProjectModel, ProjectDto>
    {
        public ProjectService(IDbRepository<ProjectModel> projectRepository, IWebProjectMapper mapper) : base(mapper, projectRepository)                 
        {
        }

        public async Task<List<ProjectDto>> GetProjectsByFilter(FilterProjectsDto filter)
        {
            var entities = await Repository.Get(x => x.ProjectStatus == filter.Status)
                .Where(sd => sd.StartDate >= filter.StartDate)
                .Where(sp => sp.CompletionDate <= filter.EndDate)
                .ToListAsync();

            var result = new List<ProjectDto>();
            foreach (var entity in entities)
            {
                result.Add(Mapper.Map<ProjectDto>(entity));
            }

            return result; 
        }

        public async Task<ProjectModel> GetProjectWithTask(int projectId)
        {
            // get specific projects and include project's tasks also
            var entities = await Repository.Get(x => x.Id == projectId).Include(p => p.Tasks).SingleOrDefaultAsync();
            return entities;
        }

        public async Task<ProjectDto> Create(ProjectCreateDto dto)
        {
            // get entity
            var entity = Mapper.Map<ProjectModel>(dto);
            await Repository.AddAsync(entity);
            // map entity to dto
            var result = Mapper.Map<ProjectDto>(entity);
            return result;

        } 
       
    }
}
