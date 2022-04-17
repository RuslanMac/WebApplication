using AutoMapper.QueryableExtensions;
using Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Service.Dtos;
using Service.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
     public  class TaskService : BaseService<TaskModel, TaskDto>  
    {

        private readonly IDbRepository<ProjectModel> _projectRepository;

        public TaskService(IDbRepository<TaskModel> taskRepository, IWebProjectMapper mapper, IDbRepository<ProjectModel> projectRepository)
             : base(mapper, taskRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<TaskDto> Create(TaskCreateDto dto)
        {
            //check if the project exists!
            if (await HasValidProject(dto.ProjectModelId))
            {
                //get task 
                var entity = Mapper.Map<TaskModel>(dto);
                await Repository.AddAsync(entity);

                //map result; 
                var result = Mapper.Map<TaskDto>(entity);
                return result;
            }
            throw new ArgumentException("The project id is not valid!");
        }

        public async Task<TaskDto> Update(TaskDto dto)
        {
            //check if the project exists
            if (await HasValidProject(dto.ProjectModelId))
            {
               return await base.UpdateAsync(dto);
            }
            throw new ArgumentException("The project id is not valid");

        }
        /// <summary>
        /// Checks existance of the project
        /// </summary>
        /// <param name="projectId">projectdID</param>
        /// <returns></returns>
        public async Task<bool> HasValidProject(int projectId)
        {
            var project = await _projectRepository.Get(x => x.Id == projectId).SingleOrDefaultAsync();
            if (project != null)
                return true;
            return false;   

        }
     
    



       
    }
}
