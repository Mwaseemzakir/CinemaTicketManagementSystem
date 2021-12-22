using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketManagementSystem.Controllers
{
    public class ErrorsHandlerController : Controller
    {
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
