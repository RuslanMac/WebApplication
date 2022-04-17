using Entities.Enums;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class ProjectModel : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public int Priority { get; set; } 

        public List<TaskModel> Tasks { get; set; }


    }
}
