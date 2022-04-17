using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Validation
{
     public interface IDtoValidator
    {
        Task ValidateAndThrowAsync<T>(
           T instance,
           Action<ValidationStrategy<T>> options = null,
           CancellationToken cancellationToken = default);
    }
}
