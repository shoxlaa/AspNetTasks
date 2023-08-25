using NewNotesApplication.Models;

namespace NewNotesApplication.Services
{
    public class NotesList : INotesList
    {
        private List<Note> _items = new();

        public void Add(Note item)
        {
            _items.Add(item);
            item.Id++;
        }

        public IEnumerable<Note> Get()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                yield return _items[i];
            }
        }

        public void Remove(Note note)
        {
            _items.Remove(note);
        }

        public void Edit(Note item)
        {
            var findNote = _items.SingleOrDefault(x=> x.Id == item.Id); 

            if (findNote != null)
            {
                return;
            }

            findNote.Title = item.Title;
            findNote.Description = item.Description;
            findNote.Tags = item.Tags;

            //var foundNote = _notesList.GetItems().SingleOrDefault(x => x.Id==id);

            //if (foundNote==null)
            //{
            //    return NotFound();
            //}

            //foundNote.Title = title;
            //foundNote.Description= description;
            //foundNote.Tags = tags;
        }
    }



}
