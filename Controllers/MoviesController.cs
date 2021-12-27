using CinemaTicketManagementSystem.Interfaces;
using CinemaTicketManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
namespace CinemaTicketManagementSystem.Controllers
{
    public class MoviesController : Controller
    { 
        private readonly IMoviesService _service;
        private readonly IMasterService _masterService;
        public MoviesController(IMoviesService service,IMasterService masterService)
        {
            _service = service;
            _masterService = masterService; 
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _service.GetAll("");
            ViewBag.Movies = movies;
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var producersList = await _masterService.GetAllProducersAsync();
            var cinemasList = await _masterService.GetAllCinemasAsync();
            var actorsList = await _masterService.GetAllActorsAsync();
            ViewBag.Producers = new SelectList(producersList,"Id", "FullName");
            ViewBag.Cinemas = new SelectList(cinemasList, "Id","Name");
            ViewBag.Actors = new SelectList(actorsList, "Id","FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "Description","Price", "ImageURL","StartDate","EndDate", "CinemaId", "ProducerId")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _service.AddAsync(movie);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            ViewBag.Producers = await _masterService.GetAllProducersAsync();
            ViewBag.Cinemas = await _masterService.GetAllCinemasAsync();
            ViewBag.Actors = await _masterService.GetAllActorsAsync();
            var details = await _service.GetByIdAsync(Id);
            return View(details);
        }
    }
}
