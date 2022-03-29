using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketTrackerModels
{
    public class Ticket
    {
        [Required, Key]
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string Issue { get; set; }
        [Required, StringLength(3000)]
        public string Description { get; set; }
        [Required, StringLength(3000)]
        public string Resolution { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? StartedDate { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public Priority TicketPriority { get; set; }
        [Required]
        public Status TicketStatus { get; set; }
        [Required, StringLength(64)]
        public string TicketCreatedBy { get; set; }
        public string TechAssigned { get; set; }
        [Required, Range(0, 500)]
        public double HoursOfLabor { get; set; }
        [Required]
        public string StakeholderEmails { get; set; }
        public virtual Category? Category {get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}