using FluentValidation;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.EventFeature.UpdateEvent
{
    public class EventUpdateCommandValidator : AbstractValidator<EventUpdateCommand>
    {
        public EventUpdateCommandValidator(IAreaContext areaContext,IImageContext imageContext)
        {
            
            
            
            RuleFor(p => p.EventName).NotNull().NotEmpty().WithMessage("Неверное имя").WithErrorCode("400"); 
            // ReSharper disable once IdentifierTypo
            // ReSharper disable once UnusedParameter.Local
            RuleFor(p => p.AreaId).NotEmpty().WithMessage("Пустое id пространства").MustAsync((p,tocken) =>  areaContext.IsHave(p)).WithMessage("Такого пространства нет").WithErrorCode("400");
            RuleFor(p => p.Beginning).NotEmpty().WithMessage("Пустой момент начала").Must((eventOnj, state) => !(state > eventOnj.End)).WithName("Момент начала  позже чем момент окончания").WithErrorCode("400");
            RuleFor(p => p.End).NotEmpty().WithMessage("Пустой момент окончания").WithErrorCode("400");
            RuleFor(p => p.Description).NotNull().WithMessage("Пустое описание").WithErrorCode("400");
            // ReSharper disable once IdentifierTypo
            // ReSharper disable once UnusedParameter.Local
            RuleFor(p => p.ImageId).NotEmpty().WithMessage("Пустое id изображения").MustAsync((p,tocken) =>  imageContext.IsHave(p)).WithMessage("Такого изображения нет").WithErrorCode("400");
            RuleFor(p=>p.IsHavePlaces).NotNull().WithMessage("Пустое значение есть ли билеты").WithErrorCode("400");
            
        }
    }
}
