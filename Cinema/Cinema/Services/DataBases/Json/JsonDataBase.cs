using CinemaApp.Models;

namespace CinemaApp.Services.DataBases.Json
{
    public class JsonDataBase : IDataBase
    {
        public bool Add(IModel model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IModel model)
        {
            throw new NotImplementedException();
        }

        public bool Update(IModel model)
        {
            throw new NotImplementedException();
        }
    }

    // i found the really usable library that use json file as database is fast  
    // Simple data store that saves the data in JSON format to a single file. 
    // https://github.com/ttu/json-flatfile-datastore


    //public class Json


}
