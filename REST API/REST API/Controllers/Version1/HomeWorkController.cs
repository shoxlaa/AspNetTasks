using Microsoft.AspNetCore.Mvc;

namespace REST_API.Controllers.Version1
{
    [ApiController]
    [Route("api/v1/{controller}/{action}")]
    public class HomeWorkController : Controller
    {
        [HttpGet("{id:int}")]
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
