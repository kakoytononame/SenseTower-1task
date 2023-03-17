using FluentValidation;
using SenseWebApi1.Context;
using SenseWebApi1.Features.TicketFeature.Commands.TicketsCommand;

namespace SenseWebApi1.Features.TicketFeature.Validators
{
    public class CheckTicketForUserValidator:AbstractValidator<CheckTicketForUserCommand>
    {
        public CheckTicketForUserValidator(IEventContext eventContext)
        {
            RuleFor(p => p.EventId).NotNull().NotEmpty().WithMessage("Пустое id события").Must(eventContext.HaveEvent).WithMessage("Такого события нет");
            RuleFor(p => p.OwnerId).NotNull().NotEmpty().WithMessage("Пустое id пользователя");
        }
        
    }
}
