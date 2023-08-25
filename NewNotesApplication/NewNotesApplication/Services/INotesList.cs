using NewNotesApplication.Models;

namespace NewNotesApplication.Services
{
    public interface INotesList
    {
        void Add(Note item);
        void Remove(Note note);
        IEnumerable<Note> Get();
        void Edit(Note item);   
    }



}
