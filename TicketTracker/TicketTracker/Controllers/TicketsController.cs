#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketTracker.Data;
using TicketTracker.Models;
using TicketTracker.Services;
using TicketTrackerModels;

namespace TicketTracker.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketservice;
        private readonly ICategoriesService _categoriesservice;
        private IList<Category> _categories;

        private async Task GetCategoriesSelectList()
        {
            _categories = await _categoriesservice.GetCategories();
        }
        private List<Category> GetCategories()
        {
            return Task.Run(async () => await _categoriesservice.GetCategories()).Result;
        }

        public TicketsController(ITicketService ticketService, ICategoriesService categoriesService)
        {
            _ticketservice = ticketService;
            _categoriesservice = categoriesService;
            GetCategoriesSelectList();
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketservice.GetTickets();
            return View(tickets);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticketservice.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }
        public async Task<IActionResult> QuickDetails(int? id)
        {
            var ticket = await _ticketservice.GetQuickDetailTicket(id);
            
            return View(ticket);
            
        }


        // GET: Tickets/Create
        public IActionResult Create()
        {
            _categories = GetCategories();
            ViewData["CategoryId"] = new SelectList(_categories, "Id", "Name");
            var items = Enum.GetNames(typeof(Priority)).ToList();
            ViewData["Priority"] = new SelectList(items);
            var items2 = Enum.GetNames(typeof(Status)).ToList();
            ViewData["Status"] = new SelectList(items2);
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Issue,Description,Resolution,DueDate,CompletedDate,StartedDate,CreatedDate,TicketPriority,TicketStatus,TicketCreatedBy,TechAssigned,HoursOfLabor,StakeholderEmails,CategoryId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                await _ticketservice.Add(ticket);
                return RedirectToAction(nameof(Index));
            }
            await GetCategoriesSelectList();
            ViewData["CategoryId"] = new SelectList(_categories, "Id", "Name", ticket.CategoryId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticketservice.Find((int)id);
            if (ticket == null)
            {
                return NotFound();
            }
            await GetCategoriesSelectList();
            ViewData["CategoryId"] = new SelectList(_categories, "Id", "Name", ticket.CategoryId);
            var items = Enum.GetNames(typeof(Priority)).ToList();
            ViewData["Priority"] = new SelectList(items);
            var items2 = Enum.GetNames(typeof(Status)).ToList();
            ViewData["Status"] = new SelectList(items2);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Issue,Description,Resolution,DueDate,CompletedDate,StartedDate,CreatedDate,TicketPriority,TicketStatus,TicketCreatedBy,TechAssigned,HoursOfLabor,StakeholderEmails,CategoryId")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ticketservice.Update(ticket);                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            await GetCategoriesSelectList();
            ViewData["CategoryId"] = new SelectList(_categories, "Id", "Name", ticket.CategoryId);
            var items = Enum.GetNames(typeof(Priority)).ToList();
            ViewData["Priority"] = new SelectList(items);
            var items2 = Enum.GetNames(typeof(Status)).ToList();
            ViewData["Status"] = new SelectList(items2);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticketservice.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ticketservice.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            var ticket = _ticketservice.GetTicket(id);
            return ticket != null;
        }
    }
}
