using FluentValidation;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Validation
{
    /// <summary>
    /// Validation class
    /// </summary>
    public class TaskCreateDtoValidator : AbstractValidator<TaskCreateDto>
    {
        public TaskCreateDtoValidator()
        {

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.TaskStatus).NotNull().IsInEnum();
        }
    }
}
