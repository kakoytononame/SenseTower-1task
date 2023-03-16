﻿using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Context
{
    public class TicketContext : ITicketContext
    {
        private List<Ticket> Tickets=new List<Ticket>();
        public TicketContext() 
        {
            Tickets.Add(
                new Ticket
                {
                    TicketId = Guid.Parse("7676ce96-417d-4214-9382-3eb46b4f86e3"),
                    OwnerId = Guid.Parse("d04a76aa-2f20-4af9-a39e-427623323374"),
                    EventId = Guid.Parse("4e1d7548-5605-455b-94a5-c18c4f1e9a4f")
                }
            );
            Tickets.Add(
                new Ticket
                {
                    TicketId = Guid.Parse("b15624ea-9cc3-42d4-a6a5-15c4e6697f4c"),
                    OwnerId = Guid.Parse("da2a7240-8fbb-48eb-bdcb-cc154593587f"),
                    EventId= Guid.Parse("454184a3-1be7-4738-9a01-ffe48a04f200"),
                }
            );
        }
        

        public void AddFreeTickets(Guid EventId, int CountOfTickets)
        {
            for (int i = 0; i < CountOfTickets; i++)
            {
                Tickets.Add(
                new Ticket
                {
                    TicketId = Guid.NewGuid(),
                    EventId=EventId
                });
            }
        }

        public bool CheckTicketForUser(Guid userId)
        {
            var ticket = Tickets.Where(p => p.OwnerId == userId).FirstOrDefault();
            if(ticket != null)
            {
                return true;
            }
            return false;
        }

        public bool CheckTicketForUser(Guid userId, Guid EventId)
        {
            var ticket = Tickets.Where(p => p.OwnerId == userId&&p.EventId==EventId).FirstOrDefault();
            if(ticket != null)
            {
                return true;
            }
            return false;
        }

        public void GiveTicketForUser(Guid userId, Guid ticketId)
        {
            var ticket=Tickets.Where(p => p.TicketId == ticketId).FirstOrDefault();
            if (ticket != null)
            {
                ticket.OwnerId = userId;
            }
            else
            {
                throw new ArgumentException("Такой билет не найден");
            }
        }

        public bool TicketHave(Guid ticketId)
        {
            var ticket = Tickets.Where(p => p.TicketId == ticketId).FirstOrDefault();
            if( ticket != null)
            {
                return true;
            }
            return false;
        }

        public bool UserHaveTicket(Guid userId, Guid ticketId)
        {
            var ticket = Tickets.Where(p => p.OwnerId == userId).FirstOrDefault();
            if (ticket == null)
            {
                return false;
            }
            return true;

        }
    }
}
