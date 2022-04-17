using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dtos
{
    public class TaskDto : BaseDto
    {
   
        public string Name { get; set; }
        public TaskStatus? TaskStatus { get; set; } = null;

        public string Description { get; set; }

        public int Priority { get; set; }

        public int ProjectModelId { get; set; } 

       
    }
}
