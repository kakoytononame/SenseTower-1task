using AutoMapper;
using MediatR;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;
using SenseWebApi1.Features.MyFeature.Commands.EventsCommands;
using SenseWebApi1.Context;
using Microsoft.Extensions.Logging;

namespace SenseWebApi1.Features.MyFeature.Handlers.EventsHandlers
{
    public class EventUpdateCommandHandler : IRequestHandler<EventUpdateCommand, EventDto>
    {
        private readonly IEventContext _eventContext;
        private readonly IMapper _mapper;
        private readonly IImageContext _imageContext;
        private readonly IAreaContext _areaContext;
        public EventUpdateCommandHandler(IEventContext eventContext, IMapper mapper, IImageContext imageContext, IAreaContext areaContext)
        {
            _eventContext = eventContext;
            _mapper = mapper;
            _imageContext = imageContext;
            _areaContext = areaContext;

        }
        public async Task<EventDto> Handle(EventUpdateCommand request, CancellationToken cancellationToken)
        {
            Event updateevent = _mapper.Map<EventUpdateCommand, Event>(request);
            //if (request.Beginning > request.End)
            //{
            //    throw new ArgumentException("Начало позже окончания");
            //}
            //if (_areaContext.IsHave(request.AreaId) != true || request.AreaId == null)
            //{
            //    throw new ArgumentException("Пространство не найдено");
            //}
            //if (_imageContext.IsHave(request.ImageId) != true || request.ImageId == null)
            //{
            //    throw new ArgumentException("Изображение не найдено");
            //}
            _eventContext.UpdateEvent(updateevent);
            EventDto result = _mapper.Map<Event, EventDto>(updateevent);
            return result;
        }
    }
}
