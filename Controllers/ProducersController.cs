using CinemaTicketManagementSystem.Database;
using CinemaTicketManagementSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Controllers
{
    public class ProducersController : Controller
    {

        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var producersList = await _service.GetAll("");
            ViewBag.Producers = producersList;
            return View();
        }
    }
}
