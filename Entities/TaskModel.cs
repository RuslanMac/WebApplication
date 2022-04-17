using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class TaskModel : BaseEntity
    {

        public string Name { get; set; }
        public TaskStatus TaskStatus { get; set; } = 0;

        public string Description { get; set; }
        public int Priority { get; set; }

        [Required]
        public int ProjectModelId { get; set; } = 0;
    }
}
