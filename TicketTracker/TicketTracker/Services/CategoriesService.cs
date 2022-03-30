using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTracker.Data;
using TicketTrackerModels;

namespace TicketTracker.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext _context;
        public CategoriesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }
        

    }
}
