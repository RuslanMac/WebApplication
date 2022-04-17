﻿using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dtos
{
    public class ProjectCreateDto
    {
        /// <summary>
        /// Dto to create a project (id is not required due to autoincrement)
        /// </summary>
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public ProjectStatus? ProjectStatus { get; set; } = null;

        public int Priority { get; set; }
    }
}
