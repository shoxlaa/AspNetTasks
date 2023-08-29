using CinemaApp.Models;

namespace CinemaApp.Services.DataBases.EFCore
{
    public class EFCoreDataBase : IDataBase
    {

        public Task<bool> Add(IModel model)
        {
            throw new NotImplementedException();
        }

        public List<IModel> Get()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(IModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(IModel model)
        {
            throw new NotImplementedException();
        }
    }

}
