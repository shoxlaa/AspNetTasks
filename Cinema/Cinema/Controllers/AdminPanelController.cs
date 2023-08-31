using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
