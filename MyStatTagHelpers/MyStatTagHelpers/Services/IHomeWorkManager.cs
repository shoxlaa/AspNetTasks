using System.Collections;
using MyStatTagHelpers.Models;

namespace MyStatTagHelpers.Services
{
    public interface IHomeWorkManager : IEnumerable<HomeWork>
    {
        Task<bool>        AddHomeWorkAsync(HomeWork product);
        Task<bool>         RemoveHomeWorkAsync(int id);
        Task<HomeWork?>       GetHomeWorkByIdAsync(int? id);
        Task<List<HomeWork>>      GetHomeWorksAsync();
        List<HomeWork>         GetHomeWorks();
    }
}
