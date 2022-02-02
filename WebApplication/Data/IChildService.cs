using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public interface IChildService
    {
        Task AddChildAsync(Child child);
        Task<IList<Child>> GetChildrenAsync();
    }
}