using CinemaApp.Models;

namespace CinemaApp.Services
{
    public interface IDataBase
    {
        public bool Add(IModel model); 
        public bool Remove(IModel model);
        public bool Update(IModel model);
    }




}
