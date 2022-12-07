using Microsoft.EntityFrameworkCore;
using MyStatTagHelpers.Models;
using System.Collections;

namespace MyStatTagHelpers.Services
{
    public interface IRegistationManager : IEnumerable<User>
    {
        Task<bool> Add(User user);
        Task<bool> Update(User user);
        Task<User?> Remove(User user);
        Task<List<User>> GetAll();
        List<User> GetUserById(int id);

    }
    public class RegistrationManager : IRegistationManager
    {
        private readonly HomeWorkDbContext _dbContext;

        public async Task<bool> Add(User user)
        {
            try
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<User> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> Remove(User user)
        {
            try
            {
                var result = await GetHomeWorkByIdAsync(id);

                if (result != null)
                {
                    _dbContext.HomeWorks.Remove(result);

                    await _dbContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public Task<bool> Update(User user)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


}
