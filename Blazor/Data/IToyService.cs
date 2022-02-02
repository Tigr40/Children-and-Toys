using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Data
{
    public interface IToyService
    {
        Task AddToyAsync(Toy toy);
        Task<IList<Toy>> GetAllToysAsync();
        Task DeleteToyAsync(int toyId);
    }
}