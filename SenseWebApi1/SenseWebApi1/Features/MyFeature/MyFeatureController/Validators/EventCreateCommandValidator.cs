using FluentValidation;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Validators
{
    public class EventCreateCommandValidator:AbstractValidator<EventCreateCommand>
    {
        public EventCreateCommandValidator()
        {
            RuleFor(p => p.EventId).NotEmpty();
            RuleFor(p => p.EventName).NotNull().NotEmpty();
            RuleFor(p => p.AreaId).NotEmpty();
            RuleFor(p => p.Beginning).NotEmpty();
            RuleFor(p => p.End).NotEmpty();
            RuleFor(p => p.Description).NotNull().NotEmpty();
            RuleFor(p => p.ImageId).NotEmpty();
        }
    }
}
