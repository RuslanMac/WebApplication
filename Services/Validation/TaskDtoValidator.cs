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
    public class TaskDtoValidator : AbstractValidator<TaskDto>
    {
        public TaskDtoValidator ()
        {
            RuleFor(x => x.TaskStatus)
                .NotNull()
                    .IsInEnum()
                        .WithMessage("The enum is not valid for this type");
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 100);
                
                    
                   
        }
            

            
    }
}
