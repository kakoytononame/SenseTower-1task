﻿using Amazon.Runtime.Internal;
using MediatR;

namespace SenseWebApi1.Features.TicketFeature.TicketsCommand
{
    public class GetTicketsCommand : IRequest<List<Ticket>>
    {
        public Guid TicketId { get; set; }

        public Guid? OwnerId { get; set; }

        public string? Place { get; set; }

        public Guid EventId { get; set; }
    }
}