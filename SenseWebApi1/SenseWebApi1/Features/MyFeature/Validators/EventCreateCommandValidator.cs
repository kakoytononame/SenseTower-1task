using FluentValidation;
using SenseWebApi1.Features.MyFeature.Commands.EventsCommands;

namespace SenseWebApi1.Features.MyFeature.Validators
{
    public class EventCreateCommandValidator : AbstractValidator<EventCreateCommand>
    {
        public EventCreateCommandValidator()
        {

            RuleFor(p => p.EventName).NotNull().NotEmpty().WithMessage("Неверное имя");
            RuleFor(p => p.AreaId).NotEmpty().WithMessage("Пустое id пространства");
            RuleFor(p => p.Beginning).NotEmpty();
            RuleFor(p => p.End).NotEmpty();
            RuleFor(p => p.Description).NotNull().NotEmpty();
            RuleFor(p => p.ImageId).NotEmpty().WithMessage("Пустое id изображения");
        }
    }
}
