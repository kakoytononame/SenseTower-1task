using MediatR;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;
using SenseWebApi1.Features.MyFeature.Commands.EventsCommands;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.MyFeature.Handlers.EventsHandlers
{
    public class EventCreateCommandHandler : IRequestHandler<EventCreateCommand, Guid>
    {
        private readonly IEventContext _eventContext;
        private readonly IImageContext _imageContext;
        private readonly IAreaContext _areaContext;
        public EventCreateCommandHandler(IEventContext eventContext, IImageContext imageContext,IAreaContext areaContext)
        {
            _eventContext = eventContext;
            _imageContext = imageContext;
            _areaContext = areaContext;

        }
        public async Task<Guid> Handle(EventCreateCommand command, CancellationToken cancellationToken)
        {
            Event @event = new Event();
            @event.EventId = Guid.NewGuid();
            @event.AreaId = command.AreaId;
            @event.ImageId = command.ImageId;
            @event.End = command.End;
            @event.Beginning = command.Beginning;
            @event.Description = command.Description;
            @event.EventName = command.EventName;
            if (@event.Beginning > @event.End)
            {
                throw new ArgumentException("Начало позже окончания");
            }
            if (_areaContext.IsHave(command.AreaId) != true || command.AreaId == null)
            {
                throw new ArgumentException("Пространство не найдено");
            }
            if (_imageContext.IsHave(command.ImageId) != true || command.ImageId == null)
            {
                throw new ArgumentException("Изображение не найдено");
            }
            _eventContext.AddEvent(@event);
            return @event.EventId;
        }
    }
}
