using CertamenDW.Models;
using Microsoft.AspNetCore.Mvc;

namespace CertamenDW.Controllers
{
    public class TicketController : Controller
    {
        private static List<Ticket> _tasks = new List<Ticket>()
        {
            new Ticket(1,"Acariciar Gatos", "Hacerle cariño a los michitos")
        };
        private static List<Ticket> _tasksResolved = new List<Ticket>()
        {
        };
        public IActionResult Index()
        {
            return View(_tasks);
        }
        public IActionResult Nuevo()
        {
            return View();
        }

        public IActionResult Save(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return View("Nuevo");
            }
            _tasks.Add(ticket);
            return RedirectToAction("Index");
        }

        public IActionResult Resuelto(int? id)
        {
            if (id.HasValue)
            {
                Ticket ticket = _tasks.FirstOrDefault(task => task.TicketNumber == id.Value);
                ticket.MarkAsResolved();
                _tasksResolved.Add(ticket);
                _tasks.Remove(ticket);
            }
            return View(_tasksResolved);
        }
    }
}
