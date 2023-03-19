using FluentValidation;
using SenseWebApi1.Context;
using SenseWebApi1.Features.TicketFeature.TicketsCommand;

namespace SenseWebApi1.Features.TicketFeature.Validators
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
