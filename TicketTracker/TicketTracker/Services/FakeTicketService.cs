using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTracker.Models;
using TicketTrackerModels;

namespace TicketTracker.Services
{
    public class FakeTicketService : ITicketService
    {
        private List<Ticket> _ticketList = new List<Ticket>() { 
        new Ticket()
        {
            Id = 1, CategoryId = 7, Issue = "Printer out of ink", Description = "Out of ink", HoursOfLabor = 499, CreatedDate = DateTime.Now, TicketStatus = Status.Open, TicketPriority = Priority.Critical, Resolution = "Buy a new Printer", StakeholderEmails = "blah@blah.com", TicketCreatedBy = "John Smith",

        },
        new Ticket()
        {
            Id = 2, CategoryId = 6, Issue = "Another Printer out of ink", Description = "Still Out of ink", HoursOfLabor = 498, CreatedDate = DateTime.Now, TicketStatus = Status.Open, TicketPriority = Priority.Critical, Resolution = "Buy a new Printer", StakeholderEmails = "blah2@blah.com", TicketCreatedBy = "John Smith Jr",

        },
        new Ticket()
        {
            Id = 3, CategoryId = 5, Issue = "All Printers out of ink", Description = "Still Out of ink", HoursOfLabor = 497, CreatedDate = DateTime.Now, TicketStatus = Status.Open, TicketPriority = Priority.Critical, Resolution = "Buy new Printers", StakeholderEmails = "blah3@blah.com", TicketCreatedBy = "John Smith the Third",

        }


        };
        public Task<Ticket> GetTicket(int? id)
        {
            return Task.Run(() => _ticketList.First());
        }

        public Task<List<Ticket>> GetTickets()
        {
            return Task.Run(() => _ticketList);
        }
        public async Task<TicketViewModel> GetQuickDetailTicket(int? id)
        {
            var ticket = _ticketList.First();
            if (ticket == null)
            {
                return null;
            }
            var tvm = new TicketViewModel();
            tvm.Id = ticket.Id;
            tvm.Issue = ticket.Issue;
            tvm.Priority = ticket.TicketPriority;
            tvm.Status = ticket.TicketStatus;
            tvm.TechAssigned = ticket.TechAssigned;
            return tvm;
        }

        public Task Add(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
