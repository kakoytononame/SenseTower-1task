using FluentValidation;
using MediatR;
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
                    .Select(x => x.ErrorMessage).ToArray();

                throw new ExceptionsAdapter(errors);
            }

            // Invoke the next handler
            // (can be another pipeline behavior or the request handler)
            return next();
        }
    }
}
