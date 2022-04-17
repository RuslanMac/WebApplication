using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dtos
{
    public class ProjectDto : BaseDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public ProjectStatus? ProjectStatus { get; set; } = null;

        public int Priority { get; set; }

   
    }
}
