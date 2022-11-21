using Microsoft.AspNetCore.Mvc;
using MvcWebApplication1.Models;
using MvcWebApplication1.Services;
using System.Text.Json;

namespace MvcWebApplication1.Controllers
{
    public class NotesController : Controller
    {
        public readonly INotesList _notesList;
        public readonly JsonWriter _writer;
        public NotesController(INotesList notesList, JsonWriter jsonWriter)
        {
            _writer = jsonWriter;
            _notesList = notesList;
        }
        public IActionResult Index()
        {
            return View();
        }
        //get from server 
        //post to server 
        //https://localhost:7224/Notes/AddNotes?title=hello&description=ophfrfgrf
        [HttpPost]
        public IActionResult Add(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return BadRequest();
            }
            _notesList.AddItem(new()
            {
                Title = title,
                Description = description,
                DateTime = DateTime.Now
            });
            _writer.Write(_notesList);
            Console.WriteLine($"{title}${description}");
            return Ok();
        }

        [HttpGet]
        public IActionResult GetResult()
        {
            //_notesList.GetItems();
            var f = _writer.Read();
            return  Ok(f);
        }
        public IActionResult Edit(string title, string name, int index)
        {

            return View();
        }
    }
}
