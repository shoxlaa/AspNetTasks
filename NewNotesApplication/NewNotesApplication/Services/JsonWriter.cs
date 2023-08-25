using NewNotesApplication.Models;
using System.Text.Json;

namespace NewNotesApplication.Services
{
    public class JsonWriter
    {
        public string _fileName = "myjson.json";
        string jsonString;
        public INotesList _notesList;
        public JsonWriter(INotesList Object)
        {
            Note value = new Note() { Id=1, Title="Title ", Description="Description this item is defalt value it will be removed dont write here any common info ", Tags="Tags", DateTime="DateTime" };
            NotesList notes = new();
            notes.Add(value);

            jsonString =  JsonSerializer.Serialize<IEnumerable<Note>>(notes.Get());
            File.WriteAllText(_fileName, jsonString);


            _notesList = Object;
        }
        public void Write(INotesList value)
        {
            //JsonSerializer.Serialize<INotesList>(_fileName, value);

            jsonString = JsonSerializer.Serialize<IEnumerable<Note>>(value.Get());
             File.WriteAllText(_fileName,jsonString);  
        }
        public IEnumerable<Note> Read()
        {
            try
            {

                string jsonString = File.ReadAllText(_fileName);
                IEnumerable<Note> Notes = JsonSerializer.Deserialize<IEnumerable<Note>>(jsonString)!;
                return Notes;

            }
            catch
            {
                return new List<Note>();
            }

        }
    }



}
