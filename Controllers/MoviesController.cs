using CinemaTicketManagementSystem.Database;
using CinemaTicketManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace CinemaTicketManagementSystem.Controllers
{
    public class MoviesController : Controller
    {
        private readonly CinemaTicketDbContext _dbContext;
        public MoviesController(CinemaTicketDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var moviesList = await _dbContext.Movies
                            .Include(x => x.Cinema)
                            .ToListAsync();
            ViewBag.Movies = moviesList;
            return View();
        }
    }
}
