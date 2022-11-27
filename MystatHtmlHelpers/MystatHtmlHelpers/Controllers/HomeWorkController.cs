using Microsoft.AspNetCore.Mvc;
using MystatHtmlHelpers.Models;
using MystatHtmlHelpers.Server;

namespace MystatHtmlHelpers.Controllers
{
    public class HomeWorkController : Controller
    {
        private readonly IHomeWorkManager _homeWorkManager;
       public HomeWorkController(IHomeWorkManager homeWorks)
        {
            _homeWorkManager = homeWorks;
        }
        public async Task<IActionResult> Index()
        {
            return View( await _homeWorkManager.GetHomeWorkByIdAsync(1)) ;
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> Add([FromBody] HomeWork? hw)
        {
            if (HttpContext.Request.Method == HttpMethod.Get.Method || hw == null)
            {
                return View();
            }

             await _homeWorkManager.AddHomeWorkAsync(hw);

            return RedirectToAction("Index");
        }
    }
}
