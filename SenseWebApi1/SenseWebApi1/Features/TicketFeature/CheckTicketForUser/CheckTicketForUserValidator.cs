using FluentValidation;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.TicketFeature.CheckTicketForUser
{
    public class CheckTicketForUserValidator:AbstractValidator<CheckTicketForUserCommand>
    {
        public CheckTicketForUserValidator(IEventContext eventContext)
        {
            RuleFor(p => p.EventId).NotNull().NotEmpty().WithMessage("Пустое id события").MustAsync((id,tocken)=>eventContext.HaveEvent(id)).WithMessage("Такого события нет");
            RuleFor(p => p.OwnerId).NotNull().NotEmpty().WithMessage("Пустое id пользователя");
        }
        
    }
}
