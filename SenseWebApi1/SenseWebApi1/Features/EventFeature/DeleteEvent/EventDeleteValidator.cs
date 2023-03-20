﻿using FluentValidation;

namespace SenseWebApi1.Features.EventFeature.DeleteEvent
{
    public class EventDeleteCommandValidator : AbstractValidator<EventDeleteCommand>
    {
        public EventDeleteCommandValidator()
        {
            
            RuleFor(p => p.EventId).NotEmpty().WithMessage("Пустое id события").WithErrorCode("400");
        }
    }
}
