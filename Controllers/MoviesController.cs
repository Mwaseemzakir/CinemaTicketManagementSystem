using CinemaTicketManagementSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace CinemaTicketManagementSystem.Controllers
{
    public class MoviesController : Controller
    { 
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _service.GetAll("");
            ViewBag.Movies = movies;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
