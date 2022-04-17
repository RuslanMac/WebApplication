using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dtos
{
    /// <summary>
    /// Dto for representing a filter
    /// </summary>
    public  class FilterProjectsDto
    {
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MaxValue;

        public ProjectStatus Status { get; set; }


    }
}
