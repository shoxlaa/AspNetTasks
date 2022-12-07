using Microsoft.AspNetCore.Mvc;
using MyStatTagHelpers.Models;
using MyStatTagHelpers.Services;
using System.IO;
using System.Text;

namespace MyStatTagHelpers.Controllers
{
    public class HomeWorkController : Controller
    {
        private readonly IHomeWorkManager _homeWorkManager;
        private readonly List<HomeWork> _homeWorks = new List<HomeWork>();

        public HomeWorkController(IHomeWorkManager homeWorkManager)
        {
            _homeWorkManager = homeWorkManager;

            _homeWorks = _homeWorkManager.GetHomeWorks();
        }

        public async Task<IActionResult> Index()
        {

            return View(await _homeWorkManager.GetHomeWorksAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] HomeWork? hw)
        {

            if (hw == null)
            {
                return BadRequest();
            }

            try
            {
                hw.CreatedDate = DateTime.Now;

                await _homeWorkManager.AddHomeWorkAsync(hw);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ActionName("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Download(int id )
        {
                      
            string contentType = "application/txt";
           var l= await _homeWorkManager.GetHomeWorkByIdAsync(id);
            byte[] bytes = Encoding.UTF8.GetBytes(l.File);
            return File(bytes, contentType, $"{l.Title}.txt");
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromBody] HomeWork? hw)
        {
            if (hw == null)
            {
                return BadRequest();
            }

            var target = _homeWorks.Find(c => c.Id == hw.Id);

            if (target != null)
            {
                _homeWorks.Remove(target);
                await _homeWorkManager.RemoveHomeWorkAsync(hw.Id);

                return Ok();
            }

            return BadRequest();

        }
    }
}