using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using SenseWebApi1.domain.Exceptions;

namespace SenseWebApi1.Features.MyFeature.Validators
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
          => _validators = validators;



        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            
            // Invoke the validators
            var failures = _validators
                .Select(validator => validator.Validate(request))
                .SelectMany(result => result.Errors)
                .ToArray();
                
                

            if (failures.Length > 0)
            {
                // Map the validation failures and throw an error,
                // this stops the execution of the request
                var errors = failures
                    .GroupBy(x => x.PropertyName, y => y.ErrorMessage, (propertyname, errormessages) =>
                new
                {
                    Key = propertyname,
                    Values = errormessages.ToList(),
                })
                    .ToDictionary(x=>x.Key,y=>y.Values);

                throw new ExceptionsAdapter(errors);
            }

            // Invoke the next handler
            // (can be another pipeline behavior or the request handler)
            return next();
        }
    }
}
