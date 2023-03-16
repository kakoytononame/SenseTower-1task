using FluentValidation;
using SenseWebApi1.Context;
using SenseWebApi1.Features.TicketFeature.Commands.TicketsCommand;

namespace SenseWebApi1.Features.TicketFeature.Validators
{
    public class GiveTicketForUserValidator : AbstractValidator<GiveTicketForUserCommand>
    {
        public GiveTicketForUserValidator(ITicketContext ticketContext)
        {
            RuleFor(p => p.TicketId).NotNull().NotEmpty().WithMessage("Пустое id события").Must(ticketContext.TicketHave).WithMessage("Такого билета нет");
            RuleFor(p => p.OwnerId).NotNull().NotEmpty().WithMessage("Пустое id пользователя");
        }
    }
}
