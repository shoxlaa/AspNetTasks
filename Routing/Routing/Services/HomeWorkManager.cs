using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Routing.Models;
using System.Collections;
using System.ComponentModel;

namespace Routing.Services
{
    public class UserManager : IUserManager
    {
        private readonly UserDbContext _dbContext;
        private StreamWriter? streamWriter;

        public UserManager(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _dbContext.Users.SingleOrDefaultAsync(p => p.Id == id);
        }

        public List<User> Get()
        {
            return _dbContext.Users.Where(p => p.Id > 0).ToList();
        }

        public async Task<List<User>> GetAsync()
        {
            return await _dbContext.Users.Where(p => p.Id > 0).ToListAsync();
        }

        public async Task<bool> AddAsync(User product)
        {
            try
            {
                await _dbContext.Users.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerator<User> GetEnumerator()
        {
            foreach (var product in _dbContext.Users)
            {
                yield return product;
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);

                if (result != null)
                {
                    _dbContext.Users.Remove(result);

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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}
