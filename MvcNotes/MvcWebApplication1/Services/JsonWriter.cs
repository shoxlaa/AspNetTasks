using MvcWebApplication1.Models;
using System.Text.Json;


namespace MvcWebApplication1.Services
{
    public class JsonWriter
    {
        public string _fileName= "myjson.json";
        string jsonString;
        public INotesList _notesList;
        public JsonWriter( INotesList Object)
        {
            _notesList = Object;
        }
        public void Write(INotesList value)
        {
            //JsonSerializer.Serialize<INotesList>(_fileName, value);
            
             jsonString = JsonSerializer.Serialize<IEnumerable<Note>>(_notesList.GetItems());
            File.WriteAllText(_fileName, jsonString);
        }
        public IEnumerable<Note>Read()
        {           
            string jsonString = File.ReadAllText(_fileName);
            IEnumerable<Note> Notes = JsonSerializer.Deserialize<IEnumerable<Note>>(jsonString)!;
            return Notes;
        }
    }
}
