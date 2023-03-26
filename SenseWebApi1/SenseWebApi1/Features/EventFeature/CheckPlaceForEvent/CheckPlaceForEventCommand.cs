﻿using Amazon.Runtime.Internal;
using MediatR;

namespace SenseWebApi1.Features.EventFeature.CheckPlaceForEvent
{
    public class CheckPlaceForEventCommand: IRequest<bool>
    {
        // ReSharper disable once InconsistentNaming
        public Guid eventId { set; get; }

        // ReSharper disable once InconsistentNaming
        public int place {  set; get; }

    }
}
