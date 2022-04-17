using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebProject1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        public ProjectController()
        {

        }

        [HttpGet]
        public async Task<List<ProjectDto>> GetProjects([FromServices] ProjectService service)
        {
            var result = await service.GetAll();
            return result; 

        }

        [HttpPost("Create")]
        public async Task<ProjectDto> Create([FromServices] ProjectService service, [FromBody] ProjectCreateDto dto)
        {
            var result = await service.Create(dto);
            return result;
        }

        [HttpPut("Update")]
        public async Task<ProjectDto> Update([FromServices] ProjectService service, [FromBody] ProjectDto projectModel)
        {
            await service.UpdateAsync(projectModel); 
            return projectModel;
        }

        [HttpGet("GetPorjectsWithTasks/{projectId}")]
        public async Task<ProjectModel> GetProjectWithTasks ([FromServices] ProjectService service, int projectId)
        {
            var result = await service.GetProjectWithTask(projectId);
            return result;

        }

        [HttpDelete("{id}")]
        public async Task<int> Delete([FromServices] ProjectService service, int id)
        {
            await service.DeleteAsync(id);
            return id;

        }

        [HttpPost("FilterProjects")]
        public async Task<List<ProjectDto>> FilterProjects([FromServices] ProjectService service, [FromBody] FilterProjectsDto dto)

        {
            var result = await service.GetProjectsByFilter(dto);
            return result;
        }
        
       
    }
}
