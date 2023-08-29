using JsonFlatFileDataStore;

namespace CinemaApp.Services.DataBases.Json
{
    // i found the really usable library that use json file as database with all functionality and it is fast because use async methods  
    // Simple data store that saves the data in JSON format to a single file. 
    // https://github.com/ttu/json-flatfile-datastore



    public class JsonDbContext<T>
    {
        public string FileName { get; set; } = $"data.json";
        public DataStore dStore { get; set; }
        public IDocumentCollection<T> collection { get; set; }
        public JsonDbContext()
        {
            //if (File.Exists(FileName))
            //{
            //    File.Delete(FileName);
            //}
            dStore = new DataStore(FileName);
        }
        public JsonDbContext(string fileName)
        {
            //if (File.Exists(fileName))
            //{
            //    File.Delete(fileName);
            //}
            dStore = new DataStore(fileName);
        }

    }

}
