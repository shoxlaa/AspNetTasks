using Routing.Models;

namespace Routing.Services
{
    public interface IUserManager : IEnumerable<User>
    {

        Task<bool> AddAsync(User user);
        Task<bool> RemoveAsync(int id);
        Task<User?> GetByIdAsync(int? id);
        Task<List<User>> GetAsync();
        List<User> Get();
    }
}
