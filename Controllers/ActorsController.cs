using CinemaTicketManagementSystem.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Controllers
{
    public class ActorsController : Controller
    {
        private readonly CinemaTicketDbContext _dbContext;
        public ActorsController(CinemaTicketDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<IActionResult> Index()
        {
            var actorsList = await _dbContext.Actors.ToListAsync();
            return View(actorsList);
        }
    }
}
