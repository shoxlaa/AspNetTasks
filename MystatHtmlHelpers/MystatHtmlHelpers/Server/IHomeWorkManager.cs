using MystatHtmlHelpers.Models;

namespace MystatHtmlHelpers.Server
{
    public interface IHomeWorkManager : IEnumerable<HomeWork>
    {
        Task<bool> AddHomeWorkAsync(HomeWork product);
        Task<bool> RemoveHomeWorkAsync(int id);
        Task<HomeWork?> GetHomeWorkByIdAsync(int? id);
    }
}
