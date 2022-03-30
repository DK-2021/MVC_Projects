using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTrackerModels;

namespace TicketTracker.Services
{
    public interface ICategoriesService
    {
        Task<List<Category>> GetCategories();

    }
}
