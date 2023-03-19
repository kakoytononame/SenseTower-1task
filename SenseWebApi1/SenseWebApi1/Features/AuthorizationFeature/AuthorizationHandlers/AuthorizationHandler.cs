﻿using MediatR;

namespace SenseWebApi1.Features.AuthorizationFeature.AuthorizationHandlers
{
    public class AuthorizationHandler : IRequestHandler<AuthorizationCommand, bool>
    {
        public Task<bool> Handle(AuthorizationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}