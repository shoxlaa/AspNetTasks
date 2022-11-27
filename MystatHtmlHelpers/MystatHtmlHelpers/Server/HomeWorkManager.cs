using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MystatHtmlHelpers.Models;
using System.Collections;

namespace MystatHtmlHelpers.Server
{
	public class HomeWorkManager : IHomeWorkManager
	{
		private readonly HomeWorkDbContext _dbContext;

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
