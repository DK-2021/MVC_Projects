using TicketTracker.Models;
using TicketTrackerModels;

namespace TicketTracker.Services
{
    public interface ITicketService
    {
        Task Add(Ticket ticket);
        Task Update(Ticket ticket);
        Task<Ticket> Find(int id);   
        Task Delete(int id);

        Task Delete (Ticket ticket);
        Task<List<Ticket>> GetTickets();

        Task<Ticket> GetTicket(int? id);

        Task<TicketViewModel> GetQuickDetailTicket(int? id);


    }  
}
