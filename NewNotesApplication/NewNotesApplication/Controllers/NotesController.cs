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
            var lastValue = _writer.Read().LastOrDefault();
            if (lastValue != null)
            {
                lastId = lastValue.Id;
            }
           
            
        }
        public IActionResult Index()
        {
            return View();
        }
        //get from server 
        //post to server 
        //https://localhost:7224/Notes/AddNotes?title=hello&description=ophfrfgrf&tags=#dedede
        [HttpPost]
        public IActionResult Add(string title, string description, string dateTime, string tags)
        {

            // не имеет имеет смыслв 
            //if (string.IsNullOrWhiteSpace(description))
            //{
            //    return BadRequest();
            //}
            _notesList.Add(new()
            {
                Id = lastId++,
                Title = title,
                Description = description,
                DateTime = dateTime,
                Tags = tags
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
            return Ok(f);
        }

        [HttpPut]
        //https://localhost:7224/Notes/Edit?*id=2&title=hello&description=ophfrfgrf&tags=#dedede

        public IActionResult Edit(int id, string title, string description, string tags)
        {
            if (id==null)
            {
                return BadRequest();
            }

            var foundNote = _notesList.Get().SingleOrDefault(x => x.Id==id);
            foundNote.Title=title;
            foundNote.Description=description;
            foundNote.Tags=tags;

            _notesList.Edit(foundNote);

            _writer.Write(_notesList);

            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id==null)
            {
                return BadRequest();
            }

            var foundNote = _notesList.Get().SingleOrDefault(x => x.Id==id);

            if (foundNote==null)
            {
                return NotFound();
            }
            _notesList.Remove(foundNote);
            _writer.Write(_notesList);

            return View();
        }
    }

}
