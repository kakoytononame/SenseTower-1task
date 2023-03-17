using FluentValidation;
using SenseWebApi1.Features.MyFeature.Commands.EventsCommands;
using System.Data;

namespace SenseWebApi1.Features.MyFeature.Validators
{
    public class EventDeleteCommandValidator : AbstractValidator<EventDeleteCommand>
    {
        public EventDeleteCommandValidator()
        {
            
            RuleFor(p => p.EventId).NotEmpty().WithMessage("Пустое id события");
        }
    }
}
