using FluentValidation;
using SenseWebApi1.Context;
using SenseWebApi1.Features.TicketFeature.TicketsCommand;

namespace SenseWebApi1.Features.TicketFeature.Validators
{
    public class AddFreeTicketValidator:AbstractValidator<AddFreeTicketsCommand>
    {
        public AddFreeTicketValidator(ITicketContext ticketContext,IEventContext eventContext)
        {
            RuleFor(p => p.EventId).NotNull().NotEmpty().WithMessage("Пустое id события").MustAsync((id,tocken)=>eventContext.HaveEvent(id)).WithMessage("Такого события нет");
            RuleFor(p=>p.Countoftickets).NotNull().NotEmpty().WithMessage("Сколько именно вы хотите добавить билетов ?").LessThan(100);
        }
    }
}
