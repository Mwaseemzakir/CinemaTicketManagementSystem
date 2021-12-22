using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketManagementSystem.Controllers
{
    public class ErrorHandlerController : Controller
    {
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
