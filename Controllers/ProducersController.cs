using CinemaTicketManagementSystem.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Controllers
{
    public class ProducersController : Controller
    {
        private readonly CinemaTicketDbContext _dbContext;
        public ProducersController(CinemaTicketDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var producersList = await _dbContext.Producers.ToListAsync();
            return View();
        }
    }
}
