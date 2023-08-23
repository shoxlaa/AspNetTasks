using Microsoft.AspNetCore.Mvc;
using NewNotesApplication.Services;
using System.Formats.Asn1;

namespace NewNotesApplication.Controllers
{
    public class NotesController : Controller
    {
        public readonly INotesList _notesList;
        public readonly JsonWriter _writer;
        int lastId = 0;
        public NotesController(INotesList notesList, JsonWriter jsonWriter)
        {
            _writer = jsonWriter;
            _notesList = notesList;
            lastId =_writer.Read().LastOrDefault().Id;
        }
        public IActionResult Index()
        {
            return View();
        }
        //get from server 
        //post to server 
        //https://localhost:7224/Notes/AddNotes?title=hello&description=ophfrfgrf&tags=#dedede
        [HttpPost]
        public  IActionResult Add(string title, string description , string dateTime, string tags)
        {

            if (string.IsNullOrWhiteSpace(description))
            {
                return BadRequest();
            }
            _notesList.AddItem(new()
            {
               Id = lastId++,
                Title = title,
                Description = description,
                DateTime = dateTime,
                Tags = tags
            });
            _writer.Write(_notesList);
            Console.WriteLine($"{title}${description}");
            return  Ok();
        }

        [HttpGet]
        public IActionResult GetResult()
        {
            //_notesList.GetItems();
            var f = _writer.Read();
            return Ok(f);
        }
        public IActionResult Edit(string title, string name, int index)
        {

            return View();
        }
    }

}
