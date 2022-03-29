using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketTracker.Models;
using TicketTrackerModels;
using CaesarEncryptor;

namespace TicketTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult TestPage()
        {
            var t = new Ticket();
            t.Id = 27;
            t.TicketPriority = Priority.Routine;
            t.TicketStatus = Status.Open;
            t.TicketCreatedBy = "John Connor";
            t.StakeholderEmails = "Bob@gmail.com";
            t.Issue = "User can't create category";
            t.HoursOfLabor = 45;
            t.Description = "Some issues going on here";

            ViewData["myCustomKey"] = "This is my data";


            return View(t);
        }
        public IActionResult SimpleDataPage()
        {
            var s = new List<string>();
            ViewData["myCustomKey"] = "This is my data";
            s.Add("data 1");
            s.Add("data 2");
            s.Add("data 3");
            return View(s);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Encryptor()
        {
            var evm = new EncryptorViewModel();
            return View(evm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Encryptor([Bind("Shift, StringToEncrypt")] EncryptorViewModel evm)
        {
            var encryptor = new Encryptor();
            evm.EncryptedString = encryptor.caesarCipher(evm.StringToEncrypt, evm.Shift);
            return View(evm);
        }
        
    }
}