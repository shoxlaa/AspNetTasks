using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStatTagHelpers.Models;
using System.Collections;
using System.ComponentModel;

namespace MyStatTagHelpers.Services
{
    public class HomeWorkManager : IHomeWorkManager
    {
        private readonly HomeWorkDbContext _dbContext;
        private StreamWriter? streamWriter;

        public HomeWorkManager(HomeWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HomeWork?> GetHomeWorkByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _dbContext.HomeWorks.SingleOrDefaultAsync(p => p.Id == id);
        }

        public List<HomeWork> GetHomeWorks()
        {
            return _dbContext.HomeWorks.Where(p => p.Id > 0).ToList();
        }

        public async Task<List<HomeWork>> GetHomeWorksAsync()
        {
            return await _dbContext.HomeWorks.Where(p => p.Id > 0).ToListAsync();
        }

        public async Task<bool> AddHomeWorkAsync(HomeWork product)
        {
            try
            {
                await _dbContext.HomeWorks.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerator<HomeWork> GetEnumerator()
        {
            foreach (var product in _dbContext.HomeWorks)
            {
                yield return product;
            }
        }

        public async Task<bool> RemoveHomeWorkAsync(int id)
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
