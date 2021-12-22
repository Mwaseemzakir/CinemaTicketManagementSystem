using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketManagementSystem.Controllers
{
    public class Handler : Controller
    {
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
