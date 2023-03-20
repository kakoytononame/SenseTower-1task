using AutoMapper;
using MediatR;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.EventFeature.GetEvents
{
    public class GetEventCommandHandler : IRequestHandler<GetEventCommand, IEnumerable<EventDto>>
    {

        private readonly IEventContext _eventContext;
        private readonly IMapper _mapper;
        public GetEventCommandHandler(IMapper mapper, IEventContext eventContext)
        {
            _mapper = mapper;
            _eventContext = eventContext;
        }
        public async Task<IEnumerable<EventDto>> Handle(GetEventCommand request, CancellationToken cancellationToken)
        {

            var mappingObject = await _eventContext.GetEvents();
            var result = mappingObject.Select(entity => _mapper.Map<Event, EventDto>(entity)).ToList();
            return result;
        }
    }
}
