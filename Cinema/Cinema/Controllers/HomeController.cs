using CinemaApp.Models;
using CinemaApp.Services.DataBases.Json;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaApp.Controllers
{

    // админ панель  для удаления и создания фильма/сенаса

    // следует создать страничку для добавления фильма 
    // страничка для добавления сеанса 
    // 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly JsonDataBase _dataBase;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _dataBase = new JsonDataBase();

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}