using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public interface IToyService
    {
        Task AddToyAsync(Toy toy);
        Task<IList<Toy>> GetAllToysAsync();
        Task DeleteToyAsync(int toyId);
    }
}