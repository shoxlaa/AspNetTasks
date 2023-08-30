using CinemaApp.Models;

namespace CinemaApp.Services
{
    public interface IDataBase
    {
        public  Task<bool> Add(IModel model); 
        public  Task<bool> Remove(IModel model);
        public Task<bool> Update(IModel model); 
        public List<IModel> Get();
    }

}
