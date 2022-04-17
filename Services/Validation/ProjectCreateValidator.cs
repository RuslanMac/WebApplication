using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Validation
{
    /// <summary>
    /// Validator for ProjectDto 
    /// </summary>
   public class ProjectCreateValidator : AbstractValidator<Dtos.ProjectCreateDto>
    {
        public ProjectCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ProjectStatus).NotNull().IsInEnum();
        }
    }
}
