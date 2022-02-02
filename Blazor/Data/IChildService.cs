using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Data
{
    public interface IChildService
    {
        Task AddChildAsync(Child child);
        Task<IList<Child>> GetChildrenAsync();
    }
}