using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketTrackerModels
{
    public class Category
    {
        [Required, Key]
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string Name { get; set; }
        [Required, StringLength(2500)]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public virtual List<Ticket> Ticket { get; set; } = new List<Ticket>();

       


    }
}
