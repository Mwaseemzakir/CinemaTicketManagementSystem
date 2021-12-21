using CinemaTicketManagementSystem.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var moviesList = await _dbContext.Movies.ToListAsync();
            return View();
        }
    }
}
