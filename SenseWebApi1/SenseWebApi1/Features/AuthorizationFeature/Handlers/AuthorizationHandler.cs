using MediatR;
using SenseWebApi1.Features.AuthorizationFeature.Commands;

namespace SenseWebApi1.Features.AuthorizationFeature.Handlers
{
    public class AuthorizationHandler : IRequestHandler<AuthorizationCommand, bool>
    {
        public Task<bool> Handle(AuthorizationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
