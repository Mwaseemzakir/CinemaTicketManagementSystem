using CinemaTicketManagementSystem.Interfaces;
using CinemaTicketManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
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
            ViewBag.Producers = await _masterService.GetAllProducersAsync();
            ViewBag.Cinemas = await _masterService.GetAllCinemasAsync();
            ViewBag.Actors = await _masterService.GetAllActorsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "Description","Price", "ImageURL","StartDate","EndDate", "CinemaId", "ProducerId")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _service.Add(movie);
            return RedirectToAction("Index");
        }
    }
}
