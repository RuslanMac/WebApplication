
using FluentValidation;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Validation
{
    public class ProjectDtoValidator : AbstractValidator<ProjectDto>
    {
      public ProjectDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ProjectStatus).NotNull().IsInEnum();
         
        }

    }
}
