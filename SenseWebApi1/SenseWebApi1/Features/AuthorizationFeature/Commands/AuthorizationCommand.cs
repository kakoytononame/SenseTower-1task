using MediatR;

namespace SenseWebApi1.Features.AuthorizationFeature.Commands
{
    public class AuthorizationCommand : IRequest<bool>
    {
        public bool isAuthorized { get; set; }
    }
}
