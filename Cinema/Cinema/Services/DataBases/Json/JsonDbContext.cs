using CinemaApp.Models;
using JsonFlatFileDataStore;

namespace CinemaApp.Services.DataBases.Json
{
    // i found the really usable library that use json file as database with all functionality and it is fast because use async methods  
    // Simple data store that saves the data in JSON format to a single file. 
    // https://github.com/ttu/json-flatfile-datastore





    public class JsonDbContext
    {
        public string FileName { get; set; } = $"data.json";
        public DataStore dStore { get; set; }

        public JsonDbContext()
        {
            dStore = new(FileName);
        }

        public JsonDbContext(string fileName)
        {
            dStore = new(fileName);
        }
    }


}
