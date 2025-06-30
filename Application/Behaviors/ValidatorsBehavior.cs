using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
    internal sealed class ValidatorsBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseRequest
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidatorsBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken
            )
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var validationContext = new ValidationContext<TRequest>(request);

            var validationErrors =
                _validators.Select(validator => validator.Validate(validationContext))
                .Where(validationResult => validationResult.Errors.Any())
                .SelectMany(validationFailure => validationFailure.Errors)
                .Select(error => new ValidationError(
                    error.PropertyName, 
                    error.ErrorMessage)
                ).ToList();
            if( validationErrors.Any() )
            {
                throw new Exceptions.ValidationException(validationErrors);
            }
            return await next();
        }
    }
}
