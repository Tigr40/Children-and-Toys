using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public interface IChildService
    {
        Task<Child> AddChildAsync(Child child);
        Task<IList<Child>> GetChildrenAsync();
    }
}