using FluentValidation;
using FluentValidation.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Validation
{
    public class DtoValidator : IDtoValidator 
    {
        private readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="serviceProvider">service Provider</param>
        public DtoValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task ValidateAndThrowAsync<T>(
            T instance,
            Action<ValidationStrategy<T>> options = null,
            CancellationToken cancellationToken = default)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<T>>();
            return validator.ValidateAsync(
                instance,
                o =>
                {
                    options?.Invoke(o);
                    o.ThrowOnFailures();
                },
                cancellationToken);
        }
    
}
}
