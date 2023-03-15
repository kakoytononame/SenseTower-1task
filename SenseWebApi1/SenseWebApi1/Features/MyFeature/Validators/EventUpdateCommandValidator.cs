﻿using FluentValidation;
using SenseWebApi1.Context;
using SenseWebApi1.Features.MyFeature.Commands.EventsCommands;

namespace SenseWebApi1.Features.MyFeature.Validators
{
    public class EventUpdateCommandValidator : AbstractValidator<EventUpdateCommand>
    {
        public EventUpdateCommandValidator(IAreaContext areaContext,IImageContext imageContext)
        {
            RuleFor(p => p.EventId).NotEmpty().WithMessage("Пустое id события").WithErrorCode("400");
            RuleFor(p => p.EventName).NotNull().NotEmpty().WithMessage("Неверное имя").WithErrorCode("400"); ;
            RuleFor(p => p.AreaId).NotEmpty().WithMessage("Пустое id пространства").Must(p => areaContext.IsHave(p)).WithMessage("Такого пространства нет").WithErrorCode("400");
            RuleFor(p => p.Beginning).NotEmpty().WithMessage("Пустой момент начала").Must((eventOnj, state) => !(state > eventOnj.End)).WithName("Момент начала  позже чем момент окончания").WithErrorCode("400");
            RuleFor(p => p.End).NotEmpty().WithMessage("Пустой момент окончания").WithErrorCode("400");
            RuleFor(p => p.Description).NotNull().WithMessage("Пустое описание").WithErrorCode("400");
            RuleFor(p => p.ImageId).NotEmpty().WithMessage("Пустое id изображения").Must(p => imageContext.IsHave(p)).WithMessage("Такого изображения нет").WithErrorCode("400");
        }
    }
}
