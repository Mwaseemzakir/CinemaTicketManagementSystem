using CinemaTicketManagementSystem.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Controllers
{
    public class CinemasController : Controller
    {
        private readonly CinemaTicketDbContext _dbContext;
        public CinemasController(CinemaTicketDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var cinemasList = await _dbContext.Cinemas.ToListAsync();
            return View();
        }

    }
}
