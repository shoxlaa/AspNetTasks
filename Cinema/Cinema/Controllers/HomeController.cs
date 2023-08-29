using CinemaApp.Models;
using CinemaApp.Services.DataBases.Json;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly JsonDataBase _dataBase;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _dataBase = new JsonDataBase();
            //_dataBase.Add(new Cinema { Id=2, Name="wwwhy", Description="the best u ever know", });
        }

        public IActionResult Index()
        {
            var c = _dataBase.Get()[0];
            Console.WriteLine(c);
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