using CinemaTicketManagementSystem.Database;
using CinemaTicketManagementSystem.Interfaces;
using CinemaTicketManagementSystem.Models;
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

        [HttpPost]
        public  async Task<IActionResult> Create([Bind("FullName","Bio", "Country")]Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction("Index");
        }
      
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var details = await _service.GetByIdAsync(Id);
            ViewBag.Title = "I am setting Title of Page";
            return View(details);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var details = await _service.GetByIdAsync(Id);
            return View(details);
        }

        public async Task<IActionResult> Update(Producer model)
        {
            await _service.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _service.DeleteAsync(Id);
            return RedirectToAction("Index");
        }
    }
}
