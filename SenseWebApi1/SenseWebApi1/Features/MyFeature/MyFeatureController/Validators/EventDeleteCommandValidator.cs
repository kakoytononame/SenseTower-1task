using FluentValidation;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.EventsCommands;
using System.Data;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Validators
{
    public class EventDeleteCommandValidator:AbstractValidator<EventDeleteCommand>
    {
        public EventDeleteCommandValidator() 
        {
            RuleFor(p => p.EventId).NotEmpty();
        }
    }
}
