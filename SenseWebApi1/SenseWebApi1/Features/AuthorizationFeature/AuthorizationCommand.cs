using MediatR;

namespace SenseWebApi1.Features.AuthorizationFeature
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AuthorizationCommand : IRequest<bool>
    {
        // ReSharper disable once InconsistentNaming
        public bool isAuthorized { get; set; }
    }
}
