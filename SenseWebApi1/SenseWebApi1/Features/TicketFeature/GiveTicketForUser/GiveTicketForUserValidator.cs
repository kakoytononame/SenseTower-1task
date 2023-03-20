using FluentValidation;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.TicketFeature.GiveTicketForUser
{
    public class GiveTicketForUserValidator : AbstractValidator<GiveTicketForUserCommand>
    {
        public GiveTicketForUserValidator(ITicketContext ticketContext)
        {
            // ReSharper disable once IdentifierTypo
            // ReSharper disable once UnusedParameter.Local
            RuleFor(p => p.TicketId).NotNull().NotEmpty().WithMessage("Пустое id события").MustAsync((id,tocken)=>ticketContext.TicketHave(id)).WithMessage("Такого билета нет").WithErrorCode("400"); ;
            RuleFor(p => p.OwnerId).NotNull().NotEmpty().WithMessage("Пустое id пользователя").WithErrorCode("400");
            
        }
    }
}
