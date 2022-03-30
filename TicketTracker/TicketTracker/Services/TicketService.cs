using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTracker.Data;
using TicketTracker.Models;
using TicketTrackerModels;

namespace TicketTracker.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Ticket> GetTicket(int? id)
        {
            return await _context.Tickets.Include(t => t.Category).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);          
        }

        public async Task<List<Ticket>> GetTickets()
        {
            return await _context.Tickets.Include(t => t.Category).AsNoTracking().ToListAsync();            
        }
        public async Task<TicketViewModel> GetQuickDetailTicket(int? id)
        {
            var ticket = await GetTicket(id);
            if (ticket == null)
            {
                return null;
            }
            var tvm = new TicketViewModel();
            tvm.Id = ticket.Id;
            tvm.Description = ticket.Description;
            tvm.Issue = ticket.Issue;
            tvm.Priority = ticket.TicketPriority;
            tvm.Status = ticket.TicketStatus;
            tvm.TechAssigned = ticket.TechAssigned;
            return tvm;
        }
        public async Task Add(Ticket ticket)
        {
            await _context.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }
        public async Task<Ticket> Find(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            return ticket;

        }
        public async Task Update(Ticket ticket)
        {
            var actualTicket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticket.Id);
            actualTicket.Issue = ticket.Issue;
            actualTicket.HoursOfLabor = ticket.HoursOfLabor;
            actualTicket.Description = ticket.Description;
            actualTicket.TechAssigned = ticket.TechAssigned;
            actualTicket.Resolution = ticket.Resolution;
            //_context.Update(actualTicket);
            await Task.Run(() => _context.Update(actualTicket));

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

        }
        public async Task Delete(Ticket ticket)
        {
            var actualTicket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticket.Id);
            _context.Tickets.Remove(actualTicket);
            await _context.SaveChangesAsync();
        }

    }
}
