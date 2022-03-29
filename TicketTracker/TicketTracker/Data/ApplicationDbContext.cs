using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketTrackerModels;
using TicketTracker.Models;

namespace TicketTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //purposefully empty: sets options appropriately
        }
        public ApplicationDbContext(): base()
        {
            //purposefully empty: Necessary for Scaffold
        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>(x =>
            {
                x.HasData(
                    new Category() { Id = 1, Name = "Credentials", Description = "Usernames, passwords, logins, roles, etc.", IsActive = true },
                    new Category() { Id = 2, Name = "Network", Description = "IP Address, VPN, Cable, etc.", IsActive = true },
                    new Category() { Id = 3, Name = "Usability", Description = "Webpages, buttons, links, etc.", IsActive = true }
                );
            });
        }

        public DbSet<TicketTracker.Models.TicketViewModel> TicketViewModel { get; set; }
    }
}