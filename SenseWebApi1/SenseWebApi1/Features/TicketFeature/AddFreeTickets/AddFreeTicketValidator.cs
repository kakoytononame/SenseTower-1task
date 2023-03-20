using FluentValidation;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.TicketFeature.AddFreeTickets
{
    public class AddFreeTicketValidator:AbstractValidator<AddFreeTicketsCommand>
    {
        public AddFreeTicketValidator(ITicketContext ticketContext,IEventContext eventContext)
        {
            RuleFor(p => p.EventId).NotNull().NotEmpty().WithMessage("Пустое id события").MustAsync((id,tocken)=>eventContext.HaveEvent(id)).WithMessage("Такого события нет").WithErrorCode("400"); ;
            RuleFor(p=>p.Countoftickets).NotNull().NotEmpty().WithMessage("Сколько именно вы хотите добавить билетов ?").LessThan(100).WithErrorCode("400"); ;
        }
    }
}
