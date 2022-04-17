
using Entities.Enums;

namespace Service.Dtos
{
    /// <summary>
    /// Dto to create a task (id is not required due to autoincremt for id)
    /// </summary>
    public class TaskCreateDto
    {
        public string Name { get; set; }
        public TaskStatus? TaskStatus { get; set; } = null;

        public string Description { get; set; }

        public int Priority { get; set; }

        public int ProjectModelId { get; set; }
    }
}
