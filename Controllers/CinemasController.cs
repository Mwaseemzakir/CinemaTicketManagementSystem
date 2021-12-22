using CinemaTicketManagementSystem.Database;
using CinemaTicketManagementSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;
        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var cinemas = await _service.GetAll("");
            ViewBag.Cinemas = cinemas;
            return View();
        }
    }
}
