using FluentValidation;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.TicketFeature.CheckTicketForUser
{
    public class CheckTicketForUserValidator:AbstractValidator<CheckTicketForUserCommand>
    {
        public CheckTicketForUserValidator(IEventContext eventContext)
        {
            // ReSharper disable once IdentifierTypo
            RuleFor(p => p.EventId).NotNull().NotEmpty().WithMessage("Пустое id события")
                // ReSharper disable once UnusedParameter.Local
                .MustAsync((id, tocken) => eventContext.HaveEvent(id)).WithMessage("Такого события нет").WithErrorCode("400");
            RuleFor(p => p.OwnerId).NotNull().NotEmpty().WithMessage("Пустое id пользователя").WithErrorCode("400");
        }
        
    }
}
