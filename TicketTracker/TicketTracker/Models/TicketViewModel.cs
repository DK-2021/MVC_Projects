using TicketTrackerModels;

namespace TicketTracker.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public string Issue { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public string TechAssigned { get; set; }

    }
}
