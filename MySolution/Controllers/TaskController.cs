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
    public class TaskController : Controller
    {
       
        public TaskController()
        {

        }

        [HttpPost]
        public async Task<TaskDto> Create([FromServices] TaskService service, [FromBody] TaskCreateDto taskDto)
        {
            var result = await service.Create(taskDto);
            return result;
        }

        
        [HttpPut("Update")]
        public async Task<TaskDto> Update([FromServices] TaskService service, [FromBody] TaskDto model)
        {
            var result = await service.UpdateAsync(model);
            return result;
           
        }

        [HttpGet("GetAll")]
        public async Task<List<TaskDto>> GetTask([FromServices] TaskService service)
        {
            var result = await service.GetAll();
            return result;
        }


        [HttpDelete]
        public async Task  DeleteTask([FromServices] TaskService service, int modelId)
        {
            await service.DeleteAsync(modelId);
            
        }


    }
}
