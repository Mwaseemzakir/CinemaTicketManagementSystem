using CinemaTicketManagementSystem.Database;
using CinemaTicketManagementSystem.Interfaces;
using CinemaTicketManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var actors = await _service.GetAll("","");
            return View(actors);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var actors = await _service.GetById(Id);
            return View(actors);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio,Country")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.Add(actor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var actors = await _service.GetById(Id);
            return View(actors);
        }

        public async Task<IActionResult> Update(Actor actor)
        {
            var actors = await _service.Update(actor);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int Id)
        {
            await _service.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
